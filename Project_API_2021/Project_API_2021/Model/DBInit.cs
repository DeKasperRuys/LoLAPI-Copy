using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_API_2021.Model;
using Microsoft.EntityFrameworkCore;

namespace Project_API_2021.Model
{
    public class DBInit
    {
        public static void Initialize(LeagueOfLegendsContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Factions.Any())
            {
                Faction fa0 = new Faction()
                {
                    //Champions = new List<Champion>(),
                    FactionDesciption = "Demacia Description", //Demacia is a strong, lawful society with prestigious military history. It values the ideals of justice, honor and duty highly, and its people are fiercely proud. Demacia is a self-sufficient, agrarian society, with abundant, fertile farmland, dense forest that are logged for lumber, and mountains rich with mineral resources. It is inherently defensive and insular partly in response to frequent attacks from barbarians, raiders and expansionist civilizations. Some suggest the golden age of Demacia has passed and unless it is able to adapt to a changing world - something many believe it is simple incapable of doing - that its decline is inevitable. Nevertheless, Demacia remains one of the dominant powers in Valoran, and boasts the most elite, well-trained army in all of Runeterra.
                    FactionName = "Demacia"
                };
                Faction fa1 = new Faction()
                {
                    //Champions = new List<Champion>(),
                    FactionDesciption = "Noxus Description", //Noxus a powerful empire with a fearsome reputation. To those beyond it's borders, Noxus is a brutal, expansionist and threatening, yet those who look beyond its warlike exterior see unusually inclusive society, where the strengths and talents of its people are respected and cultivated. Its people were once a fierce reaver culture until they stormed the ancient that now lies at the heart of their empire. Under threat from all sides, they aggressively took the fight to their enemies, pushing their borders outward every passing year. This struggle for survival has made the Noxians a deeply proud people who value strength above all, though that strength can manifest by many different means. Anyone can rise to a position of power and respect within Noxus if they display the necessary aptitude, regardless of social standing, background, homeland, or wealth.
                    FactionName = "Noxus"
                };


                if (!context.Champions.Any())
                {
                    Champion ch0 = new Champion()
                    {
                        Faction = fa0,
                        ChampionName = "Garen",
                        ChampionRole = "Top",
                        ReleaseDate = new DateTime(2012, 10, 3)
                        //ChampionStory = "A proud and noble soldier, Garen fights at the head of the Dauntless Vanguard."
                    };
                    Champion ch1 = new Champion()
                    {
                        Faction = fa0,
                        ChampionName = "Lux",
                        ChampionRole = "Mid",

                        ReleaseDate = new DateTime(2013, 10, 3)
                        //Secondary roles?? of roles als een tabel
                        //ChampionStory = "Luxanna Crownguard hails from Demacia, an insular realm where magical abilities are viewed with fear and suspicion. Able to bend light to her will, she grew up dreading discovery and exile, and was forced to keep her power secret in order to preserve her family’s noble status"
                    };
                    Champion ch2 = new Champion()
                    {
                        Faction = fa1,
                        ChampionName = "Darius",
                        ChampionRole = "Top",

                        ReleaseDate = new DateTime(2014, 10, 3)
                        //ChampionStory = "Darius and his brother Draven grew up as orphans in the port city of Basilich."
                    };
                    Champion ch3 = new Champion()
                    {
                        Faction = fa1,
                        ChampionName = "Draven",
                        ChampionRole = "Bottom",

                        ReleaseDate = new DateTime(2015, 10, 3)
                        //ChampionStory = "	In Noxus, warriors known as reckoners face one another in arenas where blood is spilled and strength tested—but none has ever been as celebrated as Draven"
                    };

                    context.Champions.Add(ch0);
                    context.Champions.Add(ch1);
                    context.Champions.Add(ch2);
                    context.Champions.Add(ch3);

                    if (!context.Roles.Any())
                    {
                        Role r0 = new Role()
                        {
                            RoleName = "Top",
                           // Champions = new List<Champion>()
                        };
                        Role r1 = new Role()
                        {
                            RoleName = "Jungle",
                            //Champions = new List<Champion>()
                        };
                        Role r2 = new Role()
                        {
                            RoleName = "Mid",
                            //Champions = new List<Champion>()
                        };
                        Role r3 = new Role()
                        {
                            RoleName = "Bottom",
                           // Champions = new List<Champion>()
                        };
                        Role r4 = new Role()
                        {
                            RoleName = "Support",
                          //  Champions = new List<Champion>()
                        };

                        context.Roles.Add(r0);
                        context.Roles.Add(r1);
                        context.Roles.Add(r2);
                        context.Roles.Add(r3);
                        context.Roles.Add(r4);
                       /* r0.Champions.Add(ch0);
                        r0.Champions.Add(ch2);

                        r2.Champions.Add(ch1);

                        r3.Champions.Add(ch3);*/


                        if (!context.Items.Any())
                        {
                            Item i0 = new Item()
                            {
                                ItemName = "Blade of the ruined king",

                            };
                            Item i1 = new Item()
                            {
                                ItemName = "Rabadons Deathcap"

                            };
                            Item i2 = new Item()
                            {
                                ItemName = "Trinity force"
                            };
                            context.Items.Add(i0);
                            context.Items.Add(i1);
                            context.Items.Add(i2);
                            if (!context.Backgrounds.Any())
                            {
                                Background ba0 = new Background()
                                {
                                    BackgroundOfChamp = "This is a background #0",
                                    Name = "Garen"

                                };

                                Background ba1 = new Background()
                                {
                                    BackgroundOfChamp = "This is a background #1",
                                    Name = "Lux"
                                };
                                context.Backgrounds.Add(ba0);
                                context.Backgrounds.Add(ba1);
                            }
                            
                        }
                        
                    }


                }
                context.SaveChanges();
            }


            /* if (!context.Factions.Any())
             {
                 var factions = new Faction[]
                 {
                   new Faction
                   {
                   FactionChampions = new List<Champion>(),
                   FactionDesciption = "TestDescription",
                   FactionName = "FactionName"
                   },
                   new Faction
                   {
                       FactionChampions = new List<Champion>(),
                       FactionDesciption = "TestDescript2222ion",
                       FactionName = "FactionNameNumber2"
                   }
                 };

                 foreach (Faction f in factions)
                 {
                     context.Factions.Add(f);
                 }


                 if (!context.Champions.Any())
                 {
                     var champions = new Champion[]
                     {
                       new Champion
                       {
                           ChampionFaction = factions[0],
                           ChampionName = "Testname",
                           ChampionRole = "Top",
                           //ChampionStory = "A story"
                       },
                       new Champion
                       {
                           ChampionFaction = factions[1],
                           ChampionName = "2ndchamp",
                           ChampionRole = "Mid",
                           //ChampionStory = "A story"
                       }
                     };
                     foreach (Champion c in champions)
                     {
                         context.Champions.Add(c);

                     }
                 }; context.SaveChanges();

             }*/


        }
    }
}


