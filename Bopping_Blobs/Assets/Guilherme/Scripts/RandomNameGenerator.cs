﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomNameGenerator {
    private List<string> m_allPossibleNames = new List<string>() {
        "Aaron",
        "Aaryn",
        "Andrew",
        "Andy",
        "Alex",
        "Alexander",
        "Art",
        "Arty",
        "Ashleigh",
        "Asher",
        "Ash",
        "Alexei",
        "Arthur",
        "Al",
        "Avery",
        "Aiden ",
        "Anthony",
        "Ben",
        "Benny",
        "Benjamin",
        "Benji",
        "Brandon",
        "Brendon",
        "Bruce",
        "Bryce",
        "Braden",
        "Bennett",
        "Braxton",
        "Brock",
        "Byron",
        "Benson",
        "Brody",
        "Brentley",
        "Christopher",
        "Connor",
        "Chase",
        "Calvin",
        "Corbin",
        "Clayton",
        "Cesar",
        "Conor",
        "Clark",
        "Caleb",
        "Colton",
        "Camden",
        "Colin",
        "Cayden",
        "Chance",
        "Cyrus",
        "Charles",
        "Charlie",
        "Chuck",
        "Carlos",
        "Collin",
        "Colby",
        "Colt",
        "David",
        "Dave",
        "Daniel",
        "Dan",
        "Declan",
        "Dawson",
        "Donovon",
        "Dante",
        "Derrick",
        "Drake",
        "Dax",
        "Donald",
        "Don",
        "Diego",
        "Dalton",
        "Damon",
        "Damion",
        "Daquan",
        "Dennis",
        "Dean",
        "Damien",
        "Desmond",
        "Des",
        "Dexter",
        "Davius",
        "Davis",
        "Darius",
        "DeAndre",
        "Eric",
        "Erick",
        "Erik",
        "Elijah",
        "Eli",
        "Ezra",
        "Ez",
        "Emmanuel",
        "Enzo",
        "Emory",
        "Emmitt",
        "Ethan",
        "Elias",
        "Emerson ",
        "Emery",
        "Emilio",
        "Emanuel",
        "Edison",
        "Enrique",
        "Easton",
        "Eduardo",
        "Edgar",
        "Elliot",
        "Easton",
        "Ezequiel",
        "Ezekiel ",
        "Edwin",
        "Finley",
        "Francisco",
        "Frank",
        "Finnegan",
        "Frederick",
        "Fred",
        "Freddy",
        "Flynn",
        "Fox",
        "Foster",
        "Francesco",
        "Fischer",
        "Fidel",
        "Finn",
        "Fernando",
        "Franklin",
        "Forrest",
        "Franco",
        "Fisher",
        "Finnian",
        "Fredrick",
        "Finlee",
        "Faris",
        "Felix",
        "Fabian",
        "Fletcher",
        "Ford",
        "Felipe",
        "Forest",
        "Floyd",
        "Filip",
        "Fitzgerald",
        "Fitz",
        "Grayson",
        "George",
        "Graham",
        "Gage",
        "Grady",
        "Gerard",
        "Gerardo",
        "Gerald ",
        "Gary",
        "Giovani",
        "Gilbert",
        "Gavin",
        "Giovanni",
        "Griffin",
        "Garrett",
        "Gregory",
        "Gustavo",
        "Graysen",
        "Guillermo",
        "Gibson",
        "Greyson",
        "Grant",
        "Gunner",
        "Gideon",
        "Gunnar",
        "Gianni",
        "Grey",
        "Gerald",
        "Gordon",
        "Gordo",
        "Greg",
        "Harper",
        "Hayden",
        "Hector",
        "Hayes",
        "Hank",
        "Hassan",
        "Harold",
        "Hugh",
        "Harris",
        "Henry",
        "Harrison",
        "Harlow",
        "Hugo",
        "Harry",
        "Harlan",
        "Huxley",
        "Howard",
        "Harlyn",
        "Hudson",
        "Holden",
        "Harvey",
        "Henley",
        "Hadlee",
        "Holland",
        "Houston",
        "Henrik",
        "Hakeem",
        "Hartley",
        "Harold",
        "Huxtable",
        "Isaac",
        "Ivan",
        "Ismael",
        "Issac",
        "Immanuel",
        "Irving",
        "Irvin",
        "Izaac",
        "Izaak",
        "Ike",
        "Isaiah",
        "Ishaan",
        "Isah",
        "Ishmael",
        "Isaak",
        "Ibraheem",
        "Iver",
        "Ian",
        "Ion",
        "Ibrahim",
        "Izaiah",
        "Ignacio",
        "Ismail",
        "Ilan",
        "Isidro",
        "Ignatius",
        "Ignace",
        "Iggy",
        "Jacob",
        "John",
        "Haxon",
        "Jeremiah",
        "Jaxson",
        "Juan",
        "Jonah",
        "Jasper",
        "Judah",
        "Jake",
        "Jackson",
        "Joshua",
        "Josiah",
        "Jace",
        "Jason",
        "Jameson",
        "Joel",
        "Jax",
        "Javier",
        "Josue",
        "Joseph",
        "Jack",
        "Konathan",
        "Jose",
        "Justin",
        "Jeremy",
        "Jorge",
        "Jase",
        "Jeffrey",
        "Jeff",
        "John",
        "Jonny",
        "Johnny",
        "Jefferson",
        "Jermaine",
        "Jerome",
        "Justin",
        "Jamal",
        "Joaquin",
        "Jensen",
        "Jared",
        "Jarrod",
        "Jacoby",
        "Jermaine",
        "Kevin",
        "Kingston",
        "Kingsley",
        "Karter",
        "Kenneth",
        "Killian",
        "Kane",
        "Keith",
        "Kobe",
        "Kieran",
        "Kenley",
        "Kayden",
        "Kaiden",
        "Kaleb",
        "Knox",
        "Kyler",
        "Ken",
        "Kamden",
        "Olton",
        "Kylan",
        "Kinslee",
        "Kinsley",
        "Kaden",
        "Keegan",
        "Kendrick",
        "Khalil",
        "Kian",
        "Keaton",
        "Korbin",
        "Kyle",
        "Liam",
        "Levi",
        "Leo",
        "Luca",
        "Lukas",
        "Lennox",
        "Lenny",
        "Landen",
        "Landyn",
        "Leonidas",
        "Lionel",
        "Leo",
        "Lucas",
        "Lincoln",
        "Leonardo",
        "London",
        "Leon",
        "Leighton",
        "Lawson",
        "Lawrence",
        "Lewis",
        "Layton",
        "Luke",
        "Lucas",
        "Landon",
        "Luis",
        "Lorenzo",
        "Louis",
        "Leonel",
        "Luka",
        "Landry",
        "Luciano",
        "Leonard",
        "Matthew",
        "Maddox",
        "Miguel",
        "Maximum",
        "Milo",
        "Manuel",
        "Marco",
        "Muhammad",
        "McKinley",
        "Maximilian",
        "Mateo",
        "Matteo",
        "Maverick",
        "Mark",
        "Martin",
        "Mario",
        "Marshall",
        "Matias",
        "Malcolm",
        "Moses",
        "Moshe",
        "Miles",
        "Malachi",
        "Marcus",
        "Markus",
        "Myles",
        "Miles",
        "Maximilian ",
        "Major",
        "Malik",
        "Malek",
        "Marcos",
        "Mohamed",
        "Mohammed",
        "Noah",
        "Nathaniel",
        "Norman",
        "Neal",
        "Nicolai",
        "Nathan",
        "Nicholas",
        "Nicolas",
        "Nasir",
        "Nikolas",
        "Neil",
        "Nick",
        "Nicky",
        "Nigel",
        "Natan",
        "Nash",
        "Nelson",
        "Nate",
        "Oliver",
        "Omar",
        "Oswald",
        "Octavio",
        "Obediah",
        "Omer",
        "Oshea",
        "Owen",
        "Orion",
        "Otis",
        "Oscar",
        "Oskar",
        "Osmar",
        "Oakley",
        "Otto",
        "Oren",
        "Olivier",
        "Ozzy",
        "Patrick",
        "Patrik",
        "Pat",
        "Pedro",
        "Peter",
        "Pete",
        "Petey",
        "Pierce",
        "Pierre",
        "Price",
        "Percy",
        "Preston",
        "Presley",
        "Philip",
        "Pierson",
        "Paulo",
        "Paolo",
        "Pablo",
        "Paul",
        "Phineas",
        "Pascal",
        "Pietro",
        "Pinchos",
        "Quinton",
        "Quinn",
        "Qasim",
        "Quintyn",
        "Quenten",
        "Quintin",
        "Quintrell",
        "Qi",
        "Qadar",
        "Qhama",
        "Qadeer",
        "Robert",
        "River",
        "Remington",
        "Rivington",
        "Raymond",
        "Ronan",
        "Ruben",
        "Ronald",
        "Ron",
        "Ronny",
        "Rodrigo ",
        "Roland",
        "Roman",
        "Rhett",
        "Rafael",
        "Romeo",
        "Russell",
        "Rhys",
        "Raphael",
        "Ramon",
        "Richard",
        "Ricardo",
        "Roberto",
        "Roy",
        "Samuel",
        "Sammy",
        "Sam",
        "Santiago",
        "Simon",
        "Sergio",
        "Sullivan",
        "Sully",
        "Samson",
        "Sylas",
        "Samir",
        "Shepherd",
        "Sabastian",
        "Stephen",
        "Steven",
        "Sterling",
        "Shawn",
        "Sean",
        "Shaun",
        "Salvador",
        "Stanley",
        "Stan",
        "Salvatory",
        "Sawyer",
        "Seth",
        "Soren",
        "Stefan",
        "Seamus",
        "Thomas",
        "Thom",
        "Tom",
        "Tommy",
        "Tomas",
        "Tucker",
        "Travis",
        "Ty",
        "Trevor",
        "Thaddeus",
        "Theo",
        "Terrence",
        "Terry",
        "Todd",
        "Theodore ",
        "Teddy",
        "Ted ",
        "Titus",
        "Tyson",
        "Trey",
        "Trent",
        "Turner",
        "Tyrone",
        "Taj",
        "Timothy",
        "Tim",
        "Troy",
        "Ulysses",
        "Uziel",
        "Urbian",
        "Urias",
        "Ulric",
        "Uriah",
        "Ubaldo",
        "Urijah",
        "Umor",
        "Ulrich",
        "Umer",
        "Uzuri",
        "Uwe",
        "Usama",
        "Udell",
        "Umi",
        "Ugo",
        "Undeio",
        "Vincent",
        "Vince",
        "Vinny",
        "Vin",
        "Valentin",
        "Viktor",
        "Victor",
        "Vic",
        "Vick",
        "Vik",
        "Viggo",
        "Vincenzo",
        "Virgil",
        "Vidal",
        "Varun",
        "Vernern",
        "Vladimir",
        "Vasilly",
        "Vaughan",
        "Vijay",
        "Vittorio",
        "Vadim",
        "Vivek",
        "Vladislav",
        "Vitaly"
    };

    public string GetRandomName() {
        return m_allPossibleNames[Random.Range(0, m_allPossibleNames.Count - 1)];
    }
}
