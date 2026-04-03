// Service Folder => Account Creation Sub-Folder => Name Sub-Folder

// VerifyName.cs

using ProfanityFilter;
using System.Globalization;

namespace BankManagementSystem
{
    public class VerifyName
    {


        public static bool NameVerifier(string name)
        { 
            // Now filtering names
            var filter = new ProfanityFilter.ProfanityFilter();
            if (filter.ContainsProfanity(name) || BannedTerms.Contains(name))
            {
                ConsoleNotifiers.InvalidMessage($"Error: Name contains a banned word");
                return false;
            }

            int lenght = name.Length;


            // Verifying name length
            if (lenght < 2 || lenght > 50)
            {
                ConsoleNotifiers.InvalidMessage("Invalid name length.");
                return false;
            }

            // Checking if the name contains prohibited characters
            foreach (char c in name)
            {
                // Using `UnicodeCategory` to cover all the possible letters
                // From all different langauges

                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);

                if (!(
                    category == UnicodeCategory.UppercaseLetter ||
                    category == UnicodeCategory.LowercaseLetter ||
                    category == UnicodeCategory.TitlecaseLetter ||
                    category == UnicodeCategory.ModifierLetter ||
                    category == UnicodeCategory.OtherLetter ||
                    category == UnicodeCategory.LetterNumber ||

                    // char.IsWhiteSpace(c) : detects all type of sapces in Unicode
                    // char.IsControl(c) : Detects all invisible caracters

                    char.IsControl(c) || char.IsWhiteSpace(c) && c != ' ' || // Allow only normal spaces
                    c != ' ' || c != '-' || c != '\''))

                    
                {
                    ConsoleNotifiers.InvalidMessage($"Invalid character: '{c}'");
                    ConsoleNotifiers.InvalidMessage("Invalid name caracter.");
                    return false;
                }
            }

            // Eliminating fraud AAAAAAA attempt
            int fraudCounter = 0;

            for(int i = 0; i < lenght - 1; i++)
            {
                if (name[i] == name[i+1])
                {
                    fraudCounter++;
                }
            }

            if (fraudCounter >= 4)
            {
                    ConsoleNotifiers.InvalidMessage("Fraud attempt.");
                    Environment.Exit(0);
            }

            // Prohibiting double sapces
            if(name.Contains("  "))
            {
                ConsoleNotifiers.InvalidMessage("Double spaces are prohibited.");
                return false;
            }

            return true;
        }








        private static readonly HashSet<string> BannedTerms = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            // ─── Technical / Reserved Names ───────────────────────────────────────────
            "admin", "root", "system", "user", "guest", "test", "demo", "sample",
            "temp", "null", "unknown", "default", "local", "support", "superuser",
            "sysadmin", "webmaster", "hostmaster", "postmaster", "noreply", "bot",
            "service", "api", "server", "client", "anonymous", "void", "localhost",
            "database", "debug", "dev", "prod", "staging", "backup", "config",
            "token", "secret", "password", "hash", "cache", "kernel", "daemon",

            // ─── Job Titles / Roles ────────────────────────────────────────────────────
            "ceo", "cfo", "coo", "cto", "manager", "director", "owner", "president",
            "chairman", "moderator", "operator", "staff", "employee", "official",
            "supervisor", "administrator", "banker", "teller", "auditor", "accountant",
            "intern", "consultant", "executive", "associate", "analyst", "developer",
            "engineer", "architect", "technician", "secretary", "receptionist",

            // ─── Banking / Financial Terms ─────────────────────────────────────────────
            "bank", "account", "cash", "money", "payment", "transfer", "loan",
            "credit", "debit", "salary", "finance", "funds", "wallet", "treasury",
            "investment", "deposit", "withdraw", "revenue", "profit", "interest",
            "mortgage", "insurance", "pension", "dividend", "equity", "asset",
            "liability", "ledger", "invoice", "budget", "capital", "currency",

            // ─── Real People (Politicians / Business) ─────────────────────────────────
            "elon musk", "bill gates", "jeff bezos", "donald trump", "mark zuckerberg",
            "joe biden", "barack obama", "vladimir putin", "xi jinping", "kim jongun",
            "angela merkel", "emmanuel macron", "boris johnson", "adolf hitler",
            "benito mussolini", "joseph stalin", "mao zedong", "osama bin laden",
            "saddam hussein", "muammar gaddafi", "ayatollah khamenei",
            "warren buffett", "larry page", "sergey brin", "tim cook", "sundar pichai",
            "sam altman", "jack ma", "george soros",

            // ─── Real People (Celebrities) ─────────────────────────────────────────────
            "kim kardashian", "kanye west", "taylor swift", "beyonce", "rihanna",
            "drake", "eminem", "jay z", "madonna", "michael jackson", "tupac",
            "cristiano ronaldo", "lionel messi", "lebron james", "kobe bryant",

            // ─── Brands / Corporations ────────────────────────────────────────────────
            "facebook", "google", "microsoft", "amazon", "apple", "twitter", "tiktok",
            "instagram", "youtube", "netflix", "snapchat", "linkedin", "reddit",
            "paypal", "visa", "mastercard", "stripe", "coinbase", "binance",
            "tesla", "spacex", "openai", "anthropic", "nvidia", "samsung", "sony",
            "coca cola", "pepsi", "mcdonalds", "nike", "adidas",

            // ─── Hate Groups / Extremist Terms ────────────────────────────────────────
            "nazi", "fascist", "kkk", "isis", "alqaeda", "taliban", "jihad",
            "gestapo", "waffen", "hamas", "hezbollah", "neonazi",

            // ─── Offensive / Slurs (English) ──────────────────────────────────────────
            "fuck", "f*ck", "fck", "fuk", "fucker", "fucking", "motherfucker",
            "shit", "sh*t", "shithead", "bullshit",
            "bitch", "bitches", "son of a bitch",
            "asshole", "ass", "arse",
            "damn", "bastard", "cunt", "dick", "cock", "pussy",
            "whore", "slut", "hoe", "skank", "thot",
            "faggot", "fag", "dyke", "tranny", "queer",
            "nigger", "nigga", "negro", "negress",
            "spic", "kike", "chink", "gook", "wetback", "beaner",
            "cracker", "redneck", "hillbilly", "white trash",
            "retard", "mongoloid", "moron", "idiot", "imbecile",
            "sex", "porn", "xxx", "nude", "naked", "erotic",
            "rape", "rapist", "molester", "pedophile", "predator",
            "terrorist", "murderer", "killer", "psycho",
            "loser", "scum", "trash", "garbage", "filth",
            "pimp", "prostitute", "escort",

            // Sexual & Vulgar
            "fuck", "f*ck", "fck", "fuk", "fucker", "fuckers", "fucking", "motherfucker",
            "motherfucking", "fuckface", "fuckhead", "fuckwit", "fuckboy", "fuckgirl",
            "shit", "sh*t", "shithead", "bullshit", "shitface", "shitstain", "shitbag",
            "shithole", "horseshit", "jackass", "dipshit", "apeshit",
            "bitch", "bitches", "son of a bitch", "bitchass",
            "asshole", "ass", "arse", "asswipe", "assclown", "assfucker", "asshat",
            "assface", "assbag", "asslicker", "assnugget",
            "bastard", "cunt", "cunts", "dumb cunt",
            "dick", "dickhead", "dickface", "dickweed", "dickwad", "dickbag",
            "cock", "cockhead", "cocksucker", "cocknugget", "cockwomble",
            "pussy", "pussyass",
            "whore", "whorehouse", "slut", "slutty", "hoe", "skank", "thot", "tramp",
            "cumslut", "cumrag", "cumdumpster", "cumguzzler", "cumstain",
            "blowjob", "handjob", "rimjob", "rimming", "fisting", "gangbang",
            "jizz", "spunk", "cum", "semen", "boner", "erection", "hardon",
            "tits", "titties", "boobs", "nipple", "areola",
            "vagina", "penis", "scrotum", "testicles", "ballsack", "nutsack",
            "anus", "rectum", "butthole", "ballbag",
            "dildo", "vibrator", "fleshlight", "buttplug",

            // Bigoted & Racial Slurs
            "nigger", "nigga", "negro", "negress", "nig", "nigglet",
            "spic", "spics", "wetback", "beaner", "beaners", "taco",
            "kike", "kikey", "heeb", "hymie", "yid",
            "chink", "chinks", "chinky", "gook", "gooks", "slope", "slant",
            "jap", "japs", "nip", "zipperhead",
            "raghead", "towelhead", "camel jockey", "sand nigger", "dune coon",
            "cracker", "redneck", "hillbilly", "white trash", "trailer trash",
            "coon", "spook", "jungle bunny", "porch monkey", "cotton picker",
            "Uncle Tom", "house nigger", "oreo",
            "curry muncher", "dot head", "paki", "pakis",
            "redskin", "injun", "wagon burner", "prairie nigger",
            "gypsy", "gypo", "pikey",
            "kraut", "Fritz", "hun", "jerry",
            "limey", "pommy", "frog", "dago", "wop", "guinea",
            "zipperhead", "slant eye", "chop chop",

            // Homophobic & Transphobic
            "faggot", "fag", "fags", "faggots", "fagboy",
            "dyke", "dykes", "carpet muncher", "bulldyke",
            "tranny", "trannies", "shemale", "heshe", "it",
            "queer", "homo", "homofag", "sodomite",
            "sissy", "pansy", "fairy", "limp wrist", "queen",

            // Ableist
            "retard", "retarded", "mongoloid", "moron", "idiot", "imbecile",
            "spastic", "spaz", "cripple", "gimp", "vegetable", "invalid",
            "lunatic", "maniac", "psycho", "schizo", "nutjob", "fruitcake",
            "loony", "mental", "nutcase", "wacko", "psychopath", "sociopath",
            "tard", "libtard", "conservatard",

            // Misogynistic
            "bimbo", "broads", "broad", "harlot", "strumpet", "trollop",
            "jezebel", "wench", "vixen", "temptress",
            "cow", "pig", "ugly bitch", "fat cow",
            "feminazi",

            // Violent / Criminal
            "rape", "rapist", "raper", "gang rape", "date rape",
            "molester", "child molester", "pedophile", "pedo", "paedo",
            "predator", "groomer", "creep",
            "terrorist", "murderer", "killer", "hitman", "assassin",
            "serial killer", "mass murderer", "psychopath",
            "drug dealer", "junkie", "crackhead", "meth head", "tweaker",
            "pimp", "prostitute", "escort", "hooker", "call girl",

            // General Insults
            "loser", "scum", "trash", "garbage", "filth", "vermin", "parasite",
            "scumbag", "dirtbag", "sleazebag", "douchebag", "douchebags",
            "douche", "tool", "toolbag", "meathead", "numbskull", "bonehead",
            "airhead", "dumbass", "dumbfuck", "dumbshit", "dumbo",
            "prick", "pricks", "jerk", "jerkoff", "wanker", "wankers",
            "tosser", "twat", "twats", "turd", "turdface",
            "cretin", "halfwit", "nitwit", "dimwit", "witless",
            "fatass", "lardass", "fatso", "fatty", "porker", "slob",
            "ugly", "hideous", "freak", "mutant", "degenerate",
            "coward", "wimp", "crybaby", "snowflake", "wuss",
            "poser", "fraud", "liar", "cheat", "swindler", "con artist",
            "deadbeat", "lowlife", "bottom feeder", "leech", "freeloader",
            "scammer", "spammer", "troll", "troller",

            // ─── Offensive / Slurs (French) ───────────────────────────────────────────
            "pédé", "gouine", "enculeur", "enculé", "connard", "connasse", "salope",
            "pute", "putain", "merde", "bâtard", "fumier", "ordure", "poufiasse",
            "lopette", "tantouse", "tarlouse", "travelo", "goudou", "gogol",
            "nègre", "négresse", "négro", "romano", "boche", "schleu",
            "sidaïque", "asiate", "chicano", "femmelette", "nabot",
            "sale arabe", "sale juif", "sale noir", "sale blanc",
            "con", "conne", "abruti", "abrutie", "débile", "taré", "tarée",
            "bouffon", "clodo", "clochard", "zonard",

            // ─── Offensive / Slurs (Spanish) ──────────────────────────────────────────
            "puta", "culo", "pendejo", "cabron", "chinga", "maricon",
            "mierda", "coño", "joder", "gilipollas", "polla", "idiota",
            "estupido", "imbecil", "perra", "zorra", "verga",

            // ─── Offensive / Slurs (Arabic — Romanized) ───────────────────────────────
            "kess", "kos", "kuss", "ibn el sharmouta", "sharmouta", "sharmout",
            "ayr", "zebbi", "kelb", "kalb", "hmar", "khanzir", "ibn haram",
            "wled el haram", "yel3an", "yil3an", "la3na", "manyak", "taban",

            // ─── Offensive / Slurs (German) ───────────────────────────────────────────
            "scheiße", "scheisse", "arschloch", "wichser", "hurensohn", "nutte",
            "fotze", "idiot", "vollidiot", "dummkopf", "schwuchtel",

            // ─── Offensive / Slurs (Italian) ──────────────────────────────────────────
            "cazzo", "vaffanculo", "stronzo", "puttana", "figlio di puttana",
            "coglione", "bastardo", "minchia",

            // ─── Offensive / Slurs (Portuguese) ──────────────────────────────────────
            "porra", "caralho", "buceta", "viado", "cu", "merda",
            "filho da puta", "desgraçado", "idiota",

            // ─── Offensive / Slurs (Russian — Romanized) ──────────────────────────────
            "blyad", "pizda", "hui", "ebat", "suka", "mudak", "pizdets",
            "eblan", "zalupa", "chmo",

            // ─── Offensive / Slurs (Turkish) ──────────────────────────────────────────
            "orospu", "orospu cocugu", "siktir", "amk", "amina koyim",
            "piç", "göt", "ibne", "kahpe",

            // ─── Fake / Nonsense Patterns ─────────────────────────────────────────────
            "aaaaa", "bbbbb", "xxxxx", "12345", "00000", "11111", "99999",
            "asdfg", "qwerty", "zxcvb", "abcde", "abc", "xyz", "aaa", "zzz",
        };
    }
}



