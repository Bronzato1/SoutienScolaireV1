using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SoutienScolaireV1.Azure.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        private readonly ILogger<ApplicationDbContext> _logger;

        string local_DB_path;
        string azure_DB_path;
        string executionRoot;

        //public ApplicationDbContext()
        //{
        //    // Constructor parameterless will be used for...
        //    // dotnet ef migrations add...
        //    // dotnet ef database update...
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool isDevEnv = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development" ? true : false;
            executionRoot = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot"; // where the azure function is running
            local_DB_path = Environment.GetEnvironmentVariable("local_DB_path"); // found in local.settings.json for development - Data\\database.db
            azure_DB_path = Environment.GetEnvironmentVariable("azure_DB_path"); // found in azure portal  environment variables - D:\\home\\database.db

            if (_logger != null)
            {
                _logger.LogInformation($"--> Called OnConfiguring in class ApplicationDbContext");
                _logger.LogInformation($"--> executionRoot {executionRoot}");
                _logger.LogInformation($"--> Data Source={(isDevEnv ? local_DB_path : azure_DB_path)}");
            }

            Console.WriteLine($"--> AZURE_FUNCTIONS_ENVIRONMENT: {Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")}");
            Console.WriteLine($"--> local_DB_path: {Environment.GetEnvironmentVariable("local_DB_path")}");
            Console.WriteLine($"--> isDevEnv: {isDevEnv}");

            optionsBuilder.UseSqlite($"Data Source={(isDevEnv ? local_DB_path : azure_DB_path)}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, FirstName = "Rowland", LastName = "Hackwell", Email = "rhackwell0@biglobe.ne.jp", Department = "Services", Avatar = "https://robohash.org/consequunturaperiamet.png?size=100x100&set=set1" },
                    new Employee { Id = 2, FirstName = "Marylinda", LastName = "Gellion", Email = "mgellion1@amazon.com", Department = "Support", Avatar = "https://robohash.org/ipsamsitlabore.png?size=100x100&set=set1" },
                    new Employee { Id = 3, FirstName = "Marleen", LastName = "Hannant", Email = "mhannant2@bbb.org", Department = "Sales", Avatar = "https://robohash.org/autexenim.png?size=100x100&set=set1" },
                    new Employee { Id = 4, FirstName = "Irene", LastName = "Drewet", Email = "idrewet3@symantec.com", Department = "Human Resources", Avatar = "https://robohash.org/facerevelitnihil.png?size=100x100&set=set1" },
                    new Employee { Id = 5, FirstName = "Henrietta", LastName = "Lindsay", Email = "hlindsay4@arizona.edu", Department = "Research and Development", Avatar = "https://robohash.org/quiquiaofficiis.png?size=100x100&set=set1" },
                    new Employee { Id = 6, FirstName = "Ivor", LastName = "Camell", Email = "icamell5@gov.uk", Department = "Marketing", Avatar = "https://robohash.org/etquicorrupti.png?size=100x100&set=set1" },
                    new Employee { Id = 7, FirstName = "Sianna", LastName = "Bernth", Email = "sbernth6@dmoz.org", Department = "Business Development", Avatar = "https://robohash.org/dignissimossimiliqueillum.png?size=100x100&set=set1" },
                    new Employee { Id = 8, FirstName = "Puff", LastName = "Moneypenny", Email = "pmoneypenny7@wordpress.com", Department = "Human Resources", Avatar = "https://robohash.org/aperiamrerumrepudiandae.png?size=100x100&set=set1" },
                    new Employee { Id = 9, FirstName = "Angie", LastName = "Gilstin", Email = "agilstin8@ted.com", Department = "Business Development", Avatar = "https://robohash.org/dignissimosauteligendi.png?size=100x100&set=set1" },
                    new Employee { Id = 10, FirstName = "Valentine", LastName = "Bergin", Email = "vbergin9@studiopress.com", Department = "Accounting", Avatar = "https://robohash.org/quononoccaecati.png?size=100x100&set=set1" },
                    new Employee { Id = 11, FirstName = "Lorraine", LastName = "Tayspell", Email = "ltayspella@auda.org.au", Department = "Sales", Avatar = "https://robohash.org/utquisbeatae.png?size=100x100&set=set1" },
                    new Employee { Id = 12, FirstName = "Annabela", LastName = "Abramamov", Email = "aabramamovb@un.org", Department = "Marketing", Avatar = "https://robohash.org/rerumfacilismolestiae.png?size=100x100&set=set1" },
                    new Employee { Id = 13, FirstName = "Sharona", LastName = "Opfer", Email = "sopferc@prweb.com", Department = "Support", Avatar = "https://robohash.org/exercitationemerrornulla.png?size=100x100&set=set1" },
                    new Employee { Id = 14, FirstName = "Humbert", LastName = "Roote", Email = "hrooted@xing.com", Department = "Legal", Avatar = "https://robohash.org/nonoptiosit.png?size=100x100&set=set1" },
                    new Employee { Id = 15, FirstName = "Hardy", LastName = "Kingsnod", Email = "hkingsnode@msn.com", Department = "Training", Avatar = "https://robohash.org/quibusdametut.png?size=100x100&set=set1" },
                    new Employee { Id = 16, FirstName = "Grace", LastName = "Wetherhead", Email = "gwetherheadf@quantcast.com", Department = "Product Management", Avatar = "https://robohash.org/nesciuntdelenitiut.png?size=100x100&set=set1" },
                    new Employee { Id = 17, FirstName = "Vallie", LastName = "Ferrick", Email = "vferrickg@washington.edu", Department = "Research and Development", Avatar = "https://robohash.org/temporibusvoluptatumducimus.png?size=100x100&set=set1" },
                    new Employee { Id = 18, FirstName = "Lotti", LastName = "Gusney", Email = "lgusneyh@homestead.com", Department = "Legal", Avatar = "https://robohash.org/quaeessedistinctio.png?size=100x100&set=set1" },
                    new Employee { Id = 19, FirstName = "Niki", LastName = "Andrysek", Email = "nandryseki@senate.gov", Department = "Support", Avatar = "https://robohash.org/quisquilaborum.png?size=100x100&set=set1" },
                    new Employee { Id = 20, FirstName = "Renato", LastName = "Hanse", Email = "rhansej@bbc.co.uk", Department = "Training", Avatar = "https://robohash.org/rerumdoloresporro.png?size=100x100&set=set1" },
                    new Employee { Id = 21, FirstName = "Elyssa", LastName = "Mazzilli", Email = "emazzillik@shop-pro.jp", Department = "Services", Avatar = "https://robohash.org/quiautnatus.png?size=100x100&set=set1" },
                    new Employee { Id = 22, FirstName = "Brinn", LastName = "Tuttiett", Email = "btuttiettl@goo.gl", Department = "Accounting", Avatar = "https://robohash.org/excepturidebitisaliquid.png?size=100x100&set=set1" },
                    new Employee { Id = 23, FirstName = "Maxy", LastName = "Conaghy", Email = "mconaghym@va.gov", Department = "Services", Avatar = "https://robohash.org/delectusinventoreomnis.png?size=100x100&set=set1" },
                    new Employee { Id = 24, FirstName = "Valery", LastName = "Campos", Email = "vcamposn@ibm.com", Department = "Marketing", Avatar = "https://robohash.org/aperiamquibusdamodio.png?size=100x100&set=set1" },
                    new Employee { Id = 25, FirstName = "Alphonso", LastName = "Scarbarrow", Email = "ascarbarrowo@state.tx.us", Department = "Services", Avatar = "https://robohash.org/nonconsequaturtotam.png?size=100x100&set=set1" },
                    new Employee { Id = 26, FirstName = "Corey", LastName = "Burstow", Email = "cburstowp@foxnews.com", Department = "Sales", Avatar = "https://robohash.org/utautminima.png?size=100x100&set=set1" },
                    new Employee { Id = 27, FirstName = "Adrian", LastName = "Girodin", Email = "agirodinq@mlb.com", Department = "Business Development", Avatar = "https://robohash.org/iureexanimi.png?size=100x100&set=set1" },
                    new Employee { Id = 28, FirstName = "Aubrie", LastName = "Cabrales", Email = "acabralesr@google.co.uk", Department = "Business Development", Avatar = "https://robohash.org/doloresimiliquedolores.png?size=100x100&set=set1" },
                    new Employee { Id = 29, FirstName = "Benjy", LastName = "Dymott", Email = "bdymotts@sakura.ne.jp", Department = "Support", Avatar = "https://robohash.org/quaspariaturmolestias.png?size=100x100&set=set1" },
                    new Employee { Id = 30, FirstName = "Danya", LastName = "MacArte", Email = "dmacartet@sciencedaily.com", Department = "Services", Avatar = "https://robohash.org/accusantiumetat.png?size=100x100&set=set1" },
                    new Employee { Id = 31, FirstName = "Dion", LastName = "Marzelo", Email = "dmarzelou@tmall.com", Department = "Research and Development", Avatar = "https://robohash.org/nesciuntnonrepellendus.png?size=100x100&set=set1" },
                    new Employee { Id = 32, FirstName = "Finley", LastName = "Thresh", Email = "fthreshv@senate.gov", Department = "Marketing", Avatar = "https://robohash.org/sapientequasvoluptatibus.png?size=100x100&set=set1" },
                    new Employee { Id = 33, FirstName = "Pamela", LastName = "Stillman", Email = "pstillmanw@issuu.com", Department = "Training", Avatar = "https://robohash.org/doloresdelectusveniam.png?size=100x100&set=set1" },
                    new Employee { Id = 34, FirstName = "Sharline", LastName = "Gatlin", Email = "sgatlinx@senate.gov", Department = "Services", Avatar = "https://robohash.org/commodisedconsequatur.png?size=100x100&set=set1" },
                    new Employee { Id = 35, FirstName = "Barnebas", LastName = "Burwell", Email = "bburwelly@privacy.gov.au", Department = "Marketing", Avatar = "https://robohash.org/sedlaboreblanditiis.png?size=100x100&set=set1" },
                    new Employee { Id = 36, FirstName = "Janette", LastName = "Harkes", Email = "jharkesz@facebook.com", Department = "Services", Avatar = "https://robohash.org/expeditaaliasquia.png?size=100x100&set=set1" },
                    new Employee { Id = 37, FirstName = "Clarance", LastName = "Roach", Email = "croach10@networkadvertising.org", Department = "Business Development", Avatar = "https://robohash.org/totamvelquos.png?size=100x100&set=set1" },
                    new Employee { Id = 38, FirstName = "Lauren", LastName = "Bayne", Email = "lbayne11@paypal.com", Department = "Business Development", Avatar = "https://robohash.org/repellatdoloremipsa.png?size=100x100&set=set1" },
                    new Employee { Id = 39, FirstName = "Ethan", LastName = "Stealy", Email = "estealy12@discovery.com", Department = "Research and Development", Avatar = "https://robohash.org/quosdoloreasperiores.png?size=100x100&set=set1" },
                    new Employee { Id = 40, FirstName = "Deb", LastName = "Shillabeare", Email = "dshillabeare13@washingtonpost.com", Department = "Services", Avatar = "https://robohash.org/possimusquiaid.png?size=100x100&set=set1" },
                    new Employee { Id = 41, FirstName = "Camilla", LastName = "Hallbord", Email = "challbord14@tamu.edu", Department = "Business Development", Avatar = "https://robohash.org/officiautfuga.png?size=100x100&set=set1" },
                    new Employee { Id = 42, FirstName = "Opaline", LastName = "Crackel", Email = "ocrackel15@sun.com", Department = "Sales", Avatar = "https://robohash.org/minimaconsequaturnihil.png?size=100x100&set=set1" },
                    new Employee { Id = 43, FirstName = "Lorna", LastName = "Lackie", Email = "llackie16@thetimes.co.uk", Department = "Accounting", Avatar = "https://robohash.org/maximelaboremolestias.png?size=100x100&set=set1" },
                    new Employee { Id = 44, FirstName = "Maggy", LastName = "Guillou", Email = "mguillou17@state.gov", Department = "Legal", Avatar = "https://robohash.org/quiarerumsaepe.png?size=100x100&set=set1" },
                    new Employee { Id = 45, FirstName = "Lucien", LastName = "Conigsby", Email = "lconigsby18@sitemeter.com", Department = "Training", Avatar = "https://robohash.org/errornumquamdistinctio.png?size=100x100&set=set1" },
                    new Employee { Id = 46, FirstName = "Chicky", LastName = "Mathelin", Email = "cmathelin19@howstuffworks.com", Department = "Accounting", Avatar = "https://robohash.org/consequaturofficiisrem.png?size=100x100&set=set1" },
                    new Employee { Id = 47, FirstName = "Marisa", LastName = "Craft", Email = "mcraft1a@utexas.edu", Department = "Research and Development", Avatar = "https://robohash.org/quieavelit.png?size=100x100&set=set1" },
                    new Employee { Id = 48, FirstName = "Allister", LastName = "Gennrich", Email = "agennrich1b@paypal.com", Department = "Research and Development", Avatar = "https://robohash.org/architectofugitet.png?size=100x100&set=set1" },
                    new Employee { Id = 49, FirstName = "Halimeda", LastName = "Hammerton", Email = "hhammerton1c@taobao.com", Department = "Human Resources", Avatar = "https://robohash.org/consequatursitplaceat.png?size=100x100&set=set1" },
                    new Employee { Id = 50, FirstName = "Bessy", LastName = "Crosen", Email = "bcrosen1d@dell.com", Department = "Legal", Avatar = "https://robohash.org/culparepellatincidunt.png?size=100x100&set=set1" },
                    new Employee { Id = 51, FirstName = "Yvonne", LastName = "MacDermott", Email = "ymacdermott1e@mit.edu", Department = "Human Resources", Avatar = "https://robohash.org/voluptatemquisquamofficia.png?size=100x100&set=set1" },
                    new Employee { Id = 52, FirstName = "Noell", LastName = "Leppingwell", Email = "nleppingwell1f@ca.gov", Department = "Sales", Avatar = "https://robohash.org/cupiditatesintharum.png?size=100x100&set=set1" },
                    new Employee { Id = 53, FirstName = "Gillan", LastName = "Stanyer", Email = "gstanyer1g@macromedia.com", Department = "Legal", Avatar = "https://robohash.org/modilaborumqui.png?size=100x100&set=set1" },
                    new Employee { Id = 54, FirstName = "Gerrilee", LastName = "Bullan", Email = "gbullan1h@a8.net", Department = "Marketing", Avatar = "https://robohash.org/autetdolores.png?size=100x100&set=set1" },
                    new Employee { Id = 55, FirstName = "Tate", LastName = "Klulicek", Email = "tklulicek1i@prlog.org", Department = "Product Management", Avatar = "https://robohash.org/quaeratomnisquo.png?size=100x100&set=set1" },
                    new Employee { Id = 56, FirstName = "Myrvyn", LastName = "Sell", Email = "msell1j@unblog.fr", Department = "Accounting", Avatar = "https://robohash.org/optioofficiissit.png?size=100x100&set=set1" },
                    new Employee { Id = 57, FirstName = "Charisse", LastName = "Janic", Email = "cjanic1k@about.com", Department = "Services", Avatar = "https://robohash.org/providentconsequunturofficiis.png?size=100x100&set=set1" },
                    new Employee { Id = 58, FirstName = "Gerrard", LastName = "Mullender", Email = "gmullender1l@seesaa.net", Department = "Human Resources", Avatar = "https://robohash.org/rerumculpaeum.png?size=100x100&set=set1" },
                    new Employee { Id = 59, FirstName = "Orelle", LastName = "Lowndsbrough", Email = "olowndsbrough1m@skyrock.com", Department = "Research and Development", Avatar = "https://robohash.org/hicveritatiseligendi.png?size=100x100&set=set1" },
                    new Employee { Id = 60, FirstName = "Alida", LastName = "Brizell", Email = "abrizell1n@ucla.edu", Department = "Sales", Avatar = "https://robohash.org/omnisadipisciiusto.png?size=100x100&set=set1" },
                    new Employee { Id = 61, FirstName = "Rosie", LastName = "Pryer", Email = "rpryer1o@hibu.com", Department = "Support", Avatar = "https://robohash.org/autexcepturiamet.png?size=100x100&set=set1" },
                    new Employee { Id = 62, FirstName = "Julianne", LastName = "Osborn", Email = "josborn1p@nih.gov", Department = "Product Management", Avatar = "https://robohash.org/suscipitasperioresfacilis.png?size=100x100&set=set1" },
                    new Employee { Id = 63, FirstName = "Selle", LastName = "Joiner", Email = "sjoiner1q@zimbio.com", Department = "Sales", Avatar = "https://robohash.org/ipsamestlibero.png?size=100x100&set=set1" },
                    new Employee { Id = 64, FirstName = "Ashton", LastName = "Rojel", Email = "arojel1r@infoseek.co.jp", Department = "Business Development", Avatar = "https://robohash.org/voluptateautmollitia.png?size=100x100&set=set1" },
                    new Employee { Id = 65, FirstName = "Adelaida", LastName = "Speechley", Email = "aspeechley1s@ezinearticles.com", Department = "Marketing", Avatar = "https://robohash.org/asperioresilloexplicabo.png?size=100x100&set=set1" },
                    new Employee { Id = 66, FirstName = "Ariadne", LastName = "Pixton", Email = "apixton1t@lulu.com", Department = "Accounting", Avatar = "https://robohash.org/inciduntnatusest.png?size=100x100&set=set1" },
                    new Employee { Id = 67, FirstName = "Sigismondo", LastName = "July", Email = "sjuly1u@wisc.edu", Department = "Business Development", Avatar = "https://robohash.org/temporeliberoeum.png?size=100x100&set=set1" },
                    new Employee { Id = 68, FirstName = "Perry", LastName = "Crennan", Email = "pcrennan1v@webs.com", Department = "Research and Development", Avatar = "https://robohash.org/quiveniamiusto.png?size=100x100&set=set1" },
                    new Employee { Id = 69, FirstName = "Marijo", LastName = "Siberry", Email = "msiberry1w@gizmodo.com", Department = "Support", Avatar = "https://robohash.org/debitisetin.png?size=100x100&set=set1" },
                    new Employee { Id = 70, FirstName = "Ron", LastName = "Benka", Email = "rbenka1x@networkadvertising.org", Department = "Services", Avatar = "https://robohash.org/quisplaceataut.png?size=100x100&set=set1" },
                    new Employee { Id = 71, FirstName = "Guinevere", LastName = "Park", Email = "gpark1y@disqus.com", Department = "Research and Development", Avatar = "https://robohash.org/perspiciatisliberonumquam.png?size=100x100&set=set1" },
                    new Employee { Id = 72, FirstName = "Aurelia", LastName = "Sambedge", Email = "asambedge1z@ca.gov", Department = "Product Management", Avatar = "https://robohash.org/hicquasiet.png?size=100x100&set=set1" },
                    new Employee { Id = 73, FirstName = "Barclay", LastName = "Trapp", Email = "btrapp20@constantcontact.com", Department = "Human Resources", Avatar = "https://robohash.org/temporibusmollitiaeligendi.png?size=100x100&set=set1" },
                    new Employee { Id = 74, FirstName = "Sari", LastName = "Seeley", Email = "sseeley21@chron.com", Department = "Training", Avatar = "https://robohash.org/facilisestest.png?size=100x100&set=set1" },
                    new Employee { Id = 75, FirstName = "Brod", LastName = "Woolstenholmes", Email = "bwoolstenholmes22@tmall.com", Department = "Accounting", Avatar = "https://robohash.org/doloresexillum.png?size=100x100&set=set1" },
                    new Employee { Id = 76, FirstName = "Torry", LastName = "Biddwell", Email = "tbiddwell23@dyndns.org", Department = "Legal", Avatar = "https://robohash.org/autemeumaut.png?size=100x100&set=set1" },
                    new Employee { Id = 77, FirstName = "Xever", LastName = "Capelow", Email = "xcapelow24@cbslocal.com", Department = "Training", Avatar = "https://robohash.org/estnihilpraesentium.png?size=100x100&set=set1" },
                    new Employee { Id = 78, FirstName = "Bab", LastName = "Dunsford", Email = "bdunsford25@amazon.com", Department = "Marketing", Avatar = "https://robohash.org/accusamusutconsequuntur.png?size=100x100&set=set1" },
                    new Employee { Id = 79, FirstName = "Dre", LastName = "Grishinov", Email = "dgrishinov26@prweb.com", Department = "Accounting", Avatar = "https://robohash.org/ullamerroraccusamus.png?size=100x100&set=set1" },
                    new Employee { Id = 80, FirstName = "Nobie", LastName = "Blues", Email = "nblues27@slashdot.org", Department = "Services", Avatar = "https://robohash.org/estharumtempora.png?size=100x100&set=set1" },
                    new Employee { Id = 81, FirstName = "Conrad", LastName = "Elphick", Email = "celphick28@state.gov", Department = "Research and Development", Avatar = "https://robohash.org/idinciduntconsequuntur.png?size=100x100&set=set1" },
                    new Employee { Id = 82, FirstName = "Hurley", LastName = "Thumnel", Email = "hthumnel29@cbc.ca", Department = "Business Development", Avatar = "https://robohash.org/atquedelenitiin.png?size=100x100&set=set1" },
                    new Employee { Id = 83, FirstName = "Bunny", LastName = "Braisted", Email = "bbraisted2a@ihg.com", Department = "Accounting", Avatar = "https://robohash.org/solutaillopraesentium.png?size=100x100&set=set1" },
                    new Employee { Id = 84, FirstName = "Lee", LastName = "Rentoul", Email = "lrentoul2b@addtoany.com", Department = "Marketing", Avatar = "https://robohash.org/sederrortotam.png?size=100x100&set=set1" },
                    new Employee { Id = 85, FirstName = "Falito", LastName = "Wealthall", Email = "fwealthall2c@spotify.com", Department = "Legal", Avatar = "https://robohash.org/doloremitaqueeum.png?size=100x100&set=set1" },
                    new Employee { Id = 86, FirstName = "Libbi", LastName = "Scoines", Email = "lscoines2d@prlog.org", Department = "Support", Avatar = "https://robohash.org/sedverout.png?size=100x100&set=set1" },
                    new Employee { Id = 87, FirstName = "Damien", LastName = "Lilford", Email = "dlilford2e@smh.com.au", Department = "Engineering", Avatar = "https://robohash.org/mollitiaquidemunde.png?size=100x100&set=set1" },
                    new Employee { Id = 88, FirstName = "Far", LastName = "Beig", Email = "fbeig2f@symantec.com", Department = "Legal", Avatar = "https://robohash.org/temporibussedad.png?size=100x100&set=set1" },
                    new Employee { Id = 89, FirstName = "Jenifer", LastName = "Petchey", Email = "jpetchey2g@blogtalkradio.com", Department = "Marketing", Avatar = "https://robohash.org/voluptatemducimussed.png?size=100x100&set=set1" },
                    new Employee { Id = 90, FirstName = "Freedman", LastName = "Cinnamond", Email = "fcinnamond2h@scientificamerican.com", Department = "Business Development", Avatar = "https://robohash.org/etnoncorrupti.png?size=100x100&set=set1" },
                    new Employee { Id = 91, FirstName = "Claudette", LastName = "Arnaudet", Email = "carnaudet2i@springer.com", Department = "Legal", Avatar = "https://robohash.org/facilisquamquisquam.png?size=100x100&set=set1" },
                    new Employee { Id = 92, FirstName = "Monte", LastName = "McMurrugh", Email = "mmcmurrugh2j@shareasale.com", Department = "Product Management", Avatar = "https://robohash.org/eiusrepudiandaedelectus.png?size=100x100&set=set1" },
                    new Employee { Id = 93, FirstName = "Brinna", LastName = "Semmens", Email = "bsemmens2k@google.com.hk", Department = "Sales", Avatar = "https://robohash.org/minimaquiet.png?size=100x100&set=set1" },
                    new Employee { Id = 94, FirstName = "Freddy", LastName = "Zecchinelli", Email = "fzecchinelli2l@netvibes.com", Department = "Marketing", Avatar = "https://robohash.org/asperioresperspiciatisqui.png?size=100x100&set=set1" },
                    new Employee { Id = 95, FirstName = "Ronny", LastName = "Towner", Email = "rtowner2m@nydailynews.com", Department = "Legal", Avatar = "https://robohash.org/consequaturvelitmaiores.png?size=100x100&set=set1" },
                    new Employee { Id = 96, FirstName = "Mindy", LastName = "Cusick", Email = "mcusick2n@usatoday.com", Department = "Marketing", Avatar = "https://robohash.org/itaqueautemconsectetur.png?size=100x100&set=set1" },
                    new Employee { Id = 97, FirstName = "Danielle", LastName = "Gudahy", Email = "dgudahy2o@admin.ch", Department = "Engineering", Avatar = "https://robohash.org/molestiaenequedicta.png?size=100x100&set=set1" },
                    new Employee { Id = 98, FirstName = "Clare", LastName = "Wimpress", Email = "cwimpress2p@biblegateway.com", Department = "Services", Avatar = "https://robohash.org/minusnihilunde.png?size=100x100&set=set1" },
                    new Employee { Id = 99, FirstName = "Chiquia", LastName = "Hegerty", Email = "chegerty2q@hugedomains.com", Department = "Research and Development", Avatar = "https://robohash.org/recusandaeeteos.png?size=100x100&set=set1" },
                    new Employee { Id = 100, FirstName = "Sashenka", LastName = "Coombes", Email = "scoombes2r@pcworld.com", Department = "Product Management", Avatar = "https://robohash.org/etconsecteturminus.png?size=100x100&set=set1" }
                );
        }
    }
}
