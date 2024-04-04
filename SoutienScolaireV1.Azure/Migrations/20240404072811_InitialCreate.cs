using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoutienScolaireV1.Azure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Avatar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Avatar", "Department", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "https://robohash.org/consequunturaperiamet.png?size=100x100&set=set1", "Services", "rhackwell0@biglobe.ne.jp", "Rowland", "Hackwell" },
                    { 2, "https://robohash.org/ipsamsitlabore.png?size=100x100&set=set1", "Support", "mgellion1@amazon.com", "Marylinda", "Gellion" },
                    { 3, "https://robohash.org/autexenim.png?size=100x100&set=set1", "Sales", "mhannant2@bbb.org", "Marleen", "Hannant" },
                    { 4, "https://robohash.org/facerevelitnihil.png?size=100x100&set=set1", "Human Resources", "idrewet3@symantec.com", "Irene", "Drewet" },
                    { 5, "https://robohash.org/quiquiaofficiis.png?size=100x100&set=set1", "Research and Development", "hlindsay4@arizona.edu", "Henrietta", "Lindsay" },
                    { 6, "https://robohash.org/etquicorrupti.png?size=100x100&set=set1", "Marketing", "icamell5@gov.uk", "Ivor", "Camell" },
                    { 7, "https://robohash.org/dignissimossimiliqueillum.png?size=100x100&set=set1", "Business Development", "sbernth6@dmoz.org", "Sianna", "Bernth" },
                    { 8, "https://robohash.org/aperiamrerumrepudiandae.png?size=100x100&set=set1", "Human Resources", "pmoneypenny7@wordpress.com", "Puff", "Moneypenny" },
                    { 9, "https://robohash.org/dignissimosauteligendi.png?size=100x100&set=set1", "Business Development", "agilstin8@ted.com", "Angie", "Gilstin" },
                    { 10, "https://robohash.org/quononoccaecati.png?size=100x100&set=set1", "Accounting", "vbergin9@studiopress.com", "Valentine", "Bergin" },
                    { 11, "https://robohash.org/utquisbeatae.png?size=100x100&set=set1", "Sales", "ltayspella@auda.org.au", "Lorraine", "Tayspell" },
                    { 12, "https://robohash.org/rerumfacilismolestiae.png?size=100x100&set=set1", "Marketing", "aabramamovb@un.org", "Annabela", "Abramamov" },
                    { 13, "https://robohash.org/exercitationemerrornulla.png?size=100x100&set=set1", "Support", "sopferc@prweb.com", "Sharona", "Opfer" },
                    { 14, "https://robohash.org/nonoptiosit.png?size=100x100&set=set1", "Legal", "hrooted@xing.com", "Humbert", "Roote" },
                    { 15, "https://robohash.org/quibusdametut.png?size=100x100&set=set1", "Training", "hkingsnode@msn.com", "Hardy", "Kingsnod" },
                    { 16, "https://robohash.org/nesciuntdelenitiut.png?size=100x100&set=set1", "Product Management", "gwetherheadf@quantcast.com", "Grace", "Wetherhead" },
                    { 17, "https://robohash.org/temporibusvoluptatumducimus.png?size=100x100&set=set1", "Research and Development", "vferrickg@washington.edu", "Vallie", "Ferrick" },
                    { 18, "https://robohash.org/quaeessedistinctio.png?size=100x100&set=set1", "Legal", "lgusneyh@homestead.com", "Lotti", "Gusney" },
                    { 19, "https://robohash.org/quisquilaborum.png?size=100x100&set=set1", "Support", "nandryseki@senate.gov", "Niki", "Andrysek" },
                    { 20, "https://robohash.org/rerumdoloresporro.png?size=100x100&set=set1", "Training", "rhansej@bbc.co.uk", "Renato", "Hanse" },
                    { 21, "https://robohash.org/quiautnatus.png?size=100x100&set=set1", "Services", "emazzillik@shop-pro.jp", "Elyssa", "Mazzilli" },
                    { 22, "https://robohash.org/excepturidebitisaliquid.png?size=100x100&set=set1", "Accounting", "btuttiettl@goo.gl", "Brinn", "Tuttiett" },
                    { 23, "https://robohash.org/delectusinventoreomnis.png?size=100x100&set=set1", "Services", "mconaghym@va.gov", "Maxy", "Conaghy" },
                    { 24, "https://robohash.org/aperiamquibusdamodio.png?size=100x100&set=set1", "Marketing", "vcamposn@ibm.com", "Valery", "Campos" },
                    { 25, "https://robohash.org/nonconsequaturtotam.png?size=100x100&set=set1", "Services", "ascarbarrowo@state.tx.us", "Alphonso", "Scarbarrow" },
                    { 26, "https://robohash.org/utautminima.png?size=100x100&set=set1", "Sales", "cburstowp@foxnews.com", "Corey", "Burstow" },
                    { 27, "https://robohash.org/iureexanimi.png?size=100x100&set=set1", "Business Development", "agirodinq@mlb.com", "Adrian", "Girodin" },
                    { 28, "https://robohash.org/doloresimiliquedolores.png?size=100x100&set=set1", "Business Development", "acabralesr@google.co.uk", "Aubrie", "Cabrales" },
                    { 29, "https://robohash.org/quaspariaturmolestias.png?size=100x100&set=set1", "Support", "bdymotts@sakura.ne.jp", "Benjy", "Dymott" },
                    { 30, "https://robohash.org/accusantiumetat.png?size=100x100&set=set1", "Services", "dmacartet@sciencedaily.com", "Danya", "MacArte" },
                    { 31, "https://robohash.org/nesciuntnonrepellendus.png?size=100x100&set=set1", "Research and Development", "dmarzelou@tmall.com", "Dion", "Marzelo" },
                    { 32, "https://robohash.org/sapientequasvoluptatibus.png?size=100x100&set=set1", "Marketing", "fthreshv@senate.gov", "Finley", "Thresh" },
                    { 33, "https://robohash.org/doloresdelectusveniam.png?size=100x100&set=set1", "Training", "pstillmanw@issuu.com", "Pamela", "Stillman" },
                    { 34, "https://robohash.org/commodisedconsequatur.png?size=100x100&set=set1", "Services", "sgatlinx@senate.gov", "Sharline", "Gatlin" },
                    { 35, "https://robohash.org/sedlaboreblanditiis.png?size=100x100&set=set1", "Marketing", "bburwelly@privacy.gov.au", "Barnebas", "Burwell" },
                    { 36, "https://robohash.org/expeditaaliasquia.png?size=100x100&set=set1", "Services", "jharkesz@facebook.com", "Janette", "Harkes" },
                    { 37, "https://robohash.org/totamvelquos.png?size=100x100&set=set1", "Business Development", "croach10@networkadvertising.org", "Clarance", "Roach" },
                    { 38, "https://robohash.org/repellatdoloremipsa.png?size=100x100&set=set1", "Business Development", "lbayne11@paypal.com", "Lauren", "Bayne" },
                    { 39, "https://robohash.org/quosdoloreasperiores.png?size=100x100&set=set1", "Research and Development", "estealy12@discovery.com", "Ethan", "Stealy" },
                    { 40, "https://robohash.org/possimusquiaid.png?size=100x100&set=set1", "Services", "dshillabeare13@washingtonpost.com", "Deb", "Shillabeare" },
                    { 41, "https://robohash.org/officiautfuga.png?size=100x100&set=set1", "Business Development", "challbord14@tamu.edu", "Camilla", "Hallbord" },
                    { 42, "https://robohash.org/minimaconsequaturnihil.png?size=100x100&set=set1", "Sales", "ocrackel15@sun.com", "Opaline", "Crackel" },
                    { 43, "https://robohash.org/maximelaboremolestias.png?size=100x100&set=set1", "Accounting", "llackie16@thetimes.co.uk", "Lorna", "Lackie" },
                    { 44, "https://robohash.org/quiarerumsaepe.png?size=100x100&set=set1", "Legal", "mguillou17@state.gov", "Maggy", "Guillou" },
                    { 45, "https://robohash.org/errornumquamdistinctio.png?size=100x100&set=set1", "Training", "lconigsby18@sitemeter.com", "Lucien", "Conigsby" },
                    { 46, "https://robohash.org/consequaturofficiisrem.png?size=100x100&set=set1", "Accounting", "cmathelin19@howstuffworks.com", "Chicky", "Mathelin" },
                    { 47, "https://robohash.org/quieavelit.png?size=100x100&set=set1", "Research and Development", "mcraft1a@utexas.edu", "Marisa", "Craft" },
                    { 48, "https://robohash.org/architectofugitet.png?size=100x100&set=set1", "Research and Development", "agennrich1b@paypal.com", "Allister", "Gennrich" },
                    { 49, "https://robohash.org/consequatursitplaceat.png?size=100x100&set=set1", "Human Resources", "hhammerton1c@taobao.com", "Halimeda", "Hammerton" },
                    { 50, "https://robohash.org/culparepellatincidunt.png?size=100x100&set=set1", "Legal", "bcrosen1d@dell.com", "Bessy", "Crosen" },
                    { 51, "https://robohash.org/voluptatemquisquamofficia.png?size=100x100&set=set1", "Human Resources", "ymacdermott1e@mit.edu", "Yvonne", "MacDermott" },
                    { 52, "https://robohash.org/cupiditatesintharum.png?size=100x100&set=set1", "Sales", "nleppingwell1f@ca.gov", "Noell", "Leppingwell" },
                    { 53, "https://robohash.org/modilaborumqui.png?size=100x100&set=set1", "Legal", "gstanyer1g@macromedia.com", "Gillan", "Stanyer" },
                    { 54, "https://robohash.org/autetdolores.png?size=100x100&set=set1", "Marketing", "gbullan1h@a8.net", "Gerrilee", "Bullan" },
                    { 55, "https://robohash.org/quaeratomnisquo.png?size=100x100&set=set1", "Product Management", "tklulicek1i@prlog.org", "Tate", "Klulicek" },
                    { 56, "https://robohash.org/optioofficiissit.png?size=100x100&set=set1", "Accounting", "msell1j@unblog.fr", "Myrvyn", "Sell" },
                    { 57, "https://robohash.org/providentconsequunturofficiis.png?size=100x100&set=set1", "Services", "cjanic1k@about.com", "Charisse", "Janic" },
                    { 58, "https://robohash.org/rerumculpaeum.png?size=100x100&set=set1", "Human Resources", "gmullender1l@seesaa.net", "Gerrard", "Mullender" },
                    { 59, "https://robohash.org/hicveritatiseligendi.png?size=100x100&set=set1", "Research and Development", "olowndsbrough1m@skyrock.com", "Orelle", "Lowndsbrough" },
                    { 60, "https://robohash.org/omnisadipisciiusto.png?size=100x100&set=set1", "Sales", "abrizell1n@ucla.edu", "Alida", "Brizell" },
                    { 61, "https://robohash.org/autexcepturiamet.png?size=100x100&set=set1", "Support", "rpryer1o@hibu.com", "Rosie", "Pryer" },
                    { 62, "https://robohash.org/suscipitasperioresfacilis.png?size=100x100&set=set1", "Product Management", "josborn1p@nih.gov", "Julianne", "Osborn" },
                    { 63, "https://robohash.org/ipsamestlibero.png?size=100x100&set=set1", "Sales", "sjoiner1q@zimbio.com", "Selle", "Joiner" },
                    { 64, "https://robohash.org/voluptateautmollitia.png?size=100x100&set=set1", "Business Development", "arojel1r@infoseek.co.jp", "Ashton", "Rojel" },
                    { 65, "https://robohash.org/asperioresilloexplicabo.png?size=100x100&set=set1", "Marketing", "aspeechley1s@ezinearticles.com", "Adelaida", "Speechley" },
                    { 66, "https://robohash.org/inciduntnatusest.png?size=100x100&set=set1", "Accounting", "apixton1t@lulu.com", "Ariadne", "Pixton" },
                    { 67, "https://robohash.org/temporeliberoeum.png?size=100x100&set=set1", "Business Development", "sjuly1u@wisc.edu", "Sigismondo", "July" },
                    { 68, "https://robohash.org/quiveniamiusto.png?size=100x100&set=set1", "Research and Development", "pcrennan1v@webs.com", "Perry", "Crennan" },
                    { 69, "https://robohash.org/debitisetin.png?size=100x100&set=set1", "Support", "msiberry1w@gizmodo.com", "Marijo", "Siberry" },
                    { 70, "https://robohash.org/quisplaceataut.png?size=100x100&set=set1", "Services", "rbenka1x@networkadvertising.org", "Ron", "Benka" },
                    { 71, "https://robohash.org/perspiciatisliberonumquam.png?size=100x100&set=set1", "Research and Development", "gpark1y@disqus.com", "Guinevere", "Park" },
                    { 72, "https://robohash.org/hicquasiet.png?size=100x100&set=set1", "Product Management", "asambedge1z@ca.gov", "Aurelia", "Sambedge" },
                    { 73, "https://robohash.org/temporibusmollitiaeligendi.png?size=100x100&set=set1", "Human Resources", "btrapp20@constantcontact.com", "Barclay", "Trapp" },
                    { 74, "https://robohash.org/facilisestest.png?size=100x100&set=set1", "Training", "sseeley21@chron.com", "Sari", "Seeley" },
                    { 75, "https://robohash.org/doloresexillum.png?size=100x100&set=set1", "Accounting", "bwoolstenholmes22@tmall.com", "Brod", "Woolstenholmes" },
                    { 76, "https://robohash.org/autemeumaut.png?size=100x100&set=set1", "Legal", "tbiddwell23@dyndns.org", "Torry", "Biddwell" },
                    { 77, "https://robohash.org/estnihilpraesentium.png?size=100x100&set=set1", "Training", "xcapelow24@cbslocal.com", "Xever", "Capelow" },
                    { 78, "https://robohash.org/accusamusutconsequuntur.png?size=100x100&set=set1", "Marketing", "bdunsford25@amazon.com", "Bab", "Dunsford" },
                    { 79, "https://robohash.org/ullamerroraccusamus.png?size=100x100&set=set1", "Accounting", "dgrishinov26@prweb.com", "Dre", "Grishinov" },
                    { 80, "https://robohash.org/estharumtempora.png?size=100x100&set=set1", "Services", "nblues27@slashdot.org", "Nobie", "Blues" },
                    { 81, "https://robohash.org/idinciduntconsequuntur.png?size=100x100&set=set1", "Research and Development", "celphick28@state.gov", "Conrad", "Elphick" },
                    { 82, "https://robohash.org/atquedelenitiin.png?size=100x100&set=set1", "Business Development", "hthumnel29@cbc.ca", "Hurley", "Thumnel" },
                    { 83, "https://robohash.org/solutaillopraesentium.png?size=100x100&set=set1", "Accounting", "bbraisted2a@ihg.com", "Bunny", "Braisted" },
                    { 84, "https://robohash.org/sederrortotam.png?size=100x100&set=set1", "Marketing", "lrentoul2b@addtoany.com", "Lee", "Rentoul" },
                    { 85, "https://robohash.org/doloremitaqueeum.png?size=100x100&set=set1", "Legal", "fwealthall2c@spotify.com", "Falito", "Wealthall" },
                    { 86, "https://robohash.org/sedverout.png?size=100x100&set=set1", "Support", "lscoines2d@prlog.org", "Libbi", "Scoines" },
                    { 87, "https://robohash.org/mollitiaquidemunde.png?size=100x100&set=set1", "Engineering", "dlilford2e@smh.com.au", "Damien", "Lilford" },
                    { 88, "https://robohash.org/temporibussedad.png?size=100x100&set=set1", "Legal", "fbeig2f@symantec.com", "Far", "Beig" },
                    { 89, "https://robohash.org/voluptatemducimussed.png?size=100x100&set=set1", "Marketing", "jpetchey2g@blogtalkradio.com", "Jenifer", "Petchey" },
                    { 90, "https://robohash.org/etnoncorrupti.png?size=100x100&set=set1", "Business Development", "fcinnamond2h@scientificamerican.com", "Freedman", "Cinnamond" },
                    { 91, "https://robohash.org/facilisquamquisquam.png?size=100x100&set=set1", "Legal", "carnaudet2i@springer.com", "Claudette", "Arnaudet" },
                    { 92, "https://robohash.org/eiusrepudiandaedelectus.png?size=100x100&set=set1", "Product Management", "mmcmurrugh2j@shareasale.com", "Monte", "McMurrugh" },
                    { 93, "https://robohash.org/minimaquiet.png?size=100x100&set=set1", "Sales", "bsemmens2k@google.com.hk", "Brinna", "Semmens" },
                    { 94, "https://robohash.org/asperioresperspiciatisqui.png?size=100x100&set=set1", "Marketing", "fzecchinelli2l@netvibes.com", "Freddy", "Zecchinelli" },
                    { 95, "https://robohash.org/consequaturvelitmaiores.png?size=100x100&set=set1", "Legal", "rtowner2m@nydailynews.com", "Ronny", "Towner" },
                    { 96, "https://robohash.org/itaqueautemconsectetur.png?size=100x100&set=set1", "Marketing", "mcusick2n@usatoday.com", "Mindy", "Cusick" },
                    { 97, "https://robohash.org/molestiaenequedicta.png?size=100x100&set=set1", "Engineering", "dgudahy2o@admin.ch", "Danielle", "Gudahy" },
                    { 98, "https://robohash.org/minusnihilunde.png?size=100x100&set=set1", "Services", "cwimpress2p@biblegateway.com", "Clare", "Wimpress" },
                    { 99, "https://robohash.org/recusandaeeteos.png?size=100x100&set=set1", "Research and Development", "chegerty2q@hugedomains.com", "Chiquia", "Hegerty" },
                    { 100, "https://robohash.org/etconsecteturminus.png?size=100x100&set=set1", "Product Management", "scoombes2r@pcworld.com", "Sashenka", "Coombes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
