﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerUp {
    public class PowerUpHolder {
        public PowerUp powerUp;
        public bool activated;
        public bool canActivate;
        public float powerUpTimer;

        public PowerUpHolder() {
            powerUp = null;
            activated = false;
            canActivate = true;
            powerUpTimer = 0f;
        }
    }

    public enum EPowerUps {
        SUPER_SLAM = 1,
        SUPER_SPEED = 2,
        BACK_OFF = 3,
    }

    public class PowerUpTracker : MonoBehaviour {
        public GameObject superSpeedTrail;

        public PowerUpHolder slot1 = new PowerUpHolder();
        public PowerUpHolder slot2 = new PowerUpHolder();

        public bool AreSlotsFull {
            get {
                return (slot1 != null && slot2 != null);
            }
        }

        private TaggingManager m_taggingManager;
        private TaggingIdentifier m_playerTaggingIdentifier;
        private IBoppable m_boppableInterface;
        private bool m_isPlayer;
        private UIManager m_UIManager;

        private void Start() {
            m_playerTaggingIdentifier = GetComponent<TaggingIdentifier>();
            m_taggingManager = FindObjectOfType<TaggingManager>();
            m_boppableInterface = GetComponent<IBoppable>();
            m_UIManager = FindObjectOfType<UIManager>();

            if(this.tag == "Player") {
                m_isPlayer = true;
            }

            if(m_isPlayer) {
                m_UIManager.UpdatePowerUpUI(slot1, slot2);
            }

            superSpeedTrail.SetActive(false);
        }

        private void Update() {
            if(m_isPlayer) {
                if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 2")) {
                    ActivatePowerUp1();
                }

                if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 3")) {
                    ActivatePowerUp2();
                }
            }

            CheckPowerUp(ref slot1);
            CheckPowerUp(ref slot2);
        }

        private void CheckPowerUp(ref PowerUpHolder _slot) {
            if(_slot.activated) {
                _slot.powerUpTimer -= Time.deltaTime;

                if (_slot.powerUpTimer <= 0) {
                    _slot.activated = false;
                    _slot.powerUp.ResetEffects();

                    _slot.powerUp = null;
                }

                if(m_isPlayer) {
                    m_UIManager.UpdatePowerUpUI(slot1, slot2);
                }
            }
        }

        public void AddPowerUp(PowerUp _powerUp) {
            PausedMenuManager._instance?.PlaySFX(GameController.instance.powerUpCollectedSound[Random.Range(0, GameController.instance.powerUpCollectedSound.Length)]);

            if(GameController.instance.blobGotPowerUpParticle) {
                Instantiate(GameController.instance.blobGotPowerUpParticle, transform.position, Quaternion.identity).Play();
            }

            // Debug.Log($"Power Up Received by Power Up Tracker: {_powerUp.GetHashCode()}");
            switch(_powerUp.powerUp) {
                case EPowerUps.SUPER_SPEED:
                    _powerUp.activatePowerUpAction += ActivateSuperSpeed;
                    _powerUp.resetPowerUpAction += ResetSuperSpeed;
                    break;
                case EPowerUps.SUPER_SLAM:
                    _powerUp.activatePowerUpAction += ActivateSuperSlam;
                    break;
                case EPowerUps.BACK_OFF:
                    _powerUp.activatePowerUpAction += ActivateBackOff;
                    break;
            }

            if (slot1.powerUp == null) {
                Debug.Log($"Adding power up to slot 1");
                slot1.powerUp = _powerUp;
                slot1.canActivate = true;
            } else if(slot2.powerUp == null) {
                Debug.Log($"Adding power up to slot 2");
                slot2.powerUp = _powerUp;
                slot2.canActivate = true;
            }

            if(m_isPlayer) {
                m_UIManager.UpdatePowerUpUI(slot1, slot2);
            }
        }

        public void ActivatePowerUp1() {
            ActivatePowerUp(ref slot1);
        }

        public void ActivatePowerUp2() {
            ActivatePowerUp(ref slot2);
        }

        private void ActivatePowerUp(ref PowerUpHolder _slot) {
            if(_slot.canActivate) {
                if(_slot.powerUp != null) {
                    switch(_slot.powerUp.powerUp) {
                        case EPowerUps.SUPER_SPEED:
                            if(GameController.instance.superSpeedSounds.Length > 0) {
                                PausedMenuManager._instance?.PlaySFX(GameController.instance.superSpeedSounds[Random.Range(0, GameController.instance.superSpeedSounds.Length)]);

                                if(GameController.instance.superSpeedParticle) {
                                    Instantiate(GameController.instance.superSpeedParticle, transform.position, Quaternion.identity);
                                }
                            }
                            break;
                        case EPowerUps.BACK_OFF:
                            if(GameController.instance.backOffSounds.Length > 0) {
                                PausedMenuManager._instance?.PlaySFX(GameController.instance.backOffSounds[Random.Range(0, GameController.instance.backOffSounds.Length)]);

                                if(GameController.instance.backOffParticle) {
                                    Instantiate(GameController.instance.backOffParticle, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                                }

                                if(GameController.instance.backOffDecal) {
                                    
                                    Instantiate(GameController.instance.backOffDecal, new Vector3(m_playerTaggingIdentifier.hammerBopAim.transform.position.x, 0.2f, m_playerTaggingIdentifier.hammerBopAim.transform.position.z), GameController.instance.backOffDecal.transform.rotation);
                                }
                            }
                            break;
                        case EPowerUps.SUPER_SLAM:
                            if(GameController.instance.superSlamSounds.Length > 0) {
                                PausedMenuManager._instance?.PlaySFX(GameController.instance.superSlamSounds[Random.Range(0, GameController.instance.superSlamSounds.Length)]);

                                if (GameController.instance.superSlamParticle) {
                                    Instantiate(GameController.instance.superSlamParticle, transform.position, Quaternion.identity);
                                }

                                if(GameController.instance.superSlamDecal) {
                                    Instantiate(GameController.instance.superSlamDecal, new Vector3(m_playerTaggingIdentifier.hammerBopAim.transform.position.x, 0.05f, m_playerTaggingIdentifier.hammerBopAim.transform.position.z), GameController.instance.superSlamDecal.transform.rotation);
                                }
                            }
                            break;
                    }

                    _slot.canActivate = false;
                    _slot.powerUp.ActivatePowerUp();

                    if (_slot.powerUp.hasDuration) {
                        _slot.powerUpTimer = _slot.powerUp.duration;
                        _slot.activated = true;
                    } else {
                        _slot.powerUp.ResetEffects();
                        _slot.powerUp = null;
                    }

                    if(m_isPlayer) {
                        m_UIManager.UpdatePowerUpUI(slot1, slot2);
                    }
                }
            }
        }

        private Vector3 GetPointToInstantiateDecal(Vector3 _originPosition) {
            RaycastHit hitPoint;

            if(Physics.Raycast(_originPosition, Vector3.down, out hitPoint)) {
                return hitPoint.point;
            }

            return Vector3.zero;
        }

        #region Power Up Functions
        public void ActivateSuperSpeed(float _value) {
            superSpeedTrail.SetActive(true);
            m_playerTaggingIdentifier.ExternalSpeedBoost += m_taggingManager.baseSpeed * _value;
        }

        public void ResetSuperSpeed(float _value) {
            m_playerTaggingIdentifier.ExternalSpeedBoost -= m_taggingManager.baseSpeed * _value;

            if(m_playerTaggingIdentifier.ExternalSpeedBoost <= 0) {
                superSpeedTrail.SetActive(false);
            }
        }

        public void ActivateBackOff(float _value) {
            List<TaggingIdentifier> taggingIdentifiers = FindObjectsOfType<TaggingIdentifier>().ToList();

            foreach(TaggingIdentifier player in taggingIdentifiers) {
                if(Vector3.Distance(player.transform.position, transform.position) < m_taggingManager.knockbackRadius && player.PlayerIdentifier != m_playerTaggingIdentifier.PlayerIdentifier) {
                    player.KnockbackPlayer(Color.magenta, (player.transform.position - transform.position).normalized * m_taggingManager.knockbackForce * 2f, _value);
                }
            }
        }

        public void ActivateSuperSlam(float _value) {
            m_playerTaggingIdentifier.ForceAttackWithMultiplier(_value);
        }
        #endregion

    }
}
