namespace RestaurantReservation.WebUI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RestaurantReservation.BL.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantReservation.BL.Data.ReservationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RestaurantReservation.BL.Data.ReservationDbContext";
        }

        protected override void Seed(RestaurantReservation.BL.Data.ReservationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Vegetable" },
                new Category { Name = "Meat" },
                new Category { Name = "Seafood" },
                new Category { Name = "Soup" },

            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();



            var dishes = new List<Dish>
            {
                new Dish { Name = "Braised Eggplant",
                           Description ="Grilled eggplant mixed with soy sauce and chili bean sauce",
                           StandardPrice=15M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Brocolli with Garlic",
                           Description ="Steamed brocolli with lemon juice and chopped garlic to enhance taste",
                            StandardPrice=18M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Mapo Tofu",
                           Description ="Tofu in spicy sauce and douchi along with minced meat",
                            StandardPrice=15M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Mushroom Delight",
                           Description ="Stir-fried mushrooms with wine and peppers",
                            StandardPrice=20M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Green Veggie",
                           Description ="Stir-fried green veggie includes kailan, kangkung, etc..",
                            StandardPrice=12M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Veggie Spring Rolls",
                           Description ="Steamed spring roll with shredded carrot, bean sprouts and othe vegetables",
                            StandardPrice=15M,
                           CategoryID =categories.Single( c => c.Name == "Vegetable").Id
                          },
                new Dish { Name = "Sweet Sour Pork",
                           Description ="Fried pork mixed with ketchup and vinegar and pineapple chunks",
                            StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "Red-fried Pork",
                           Description ="Red-stewd pork belly served with thickened braising sauce",
                            StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "Herbal Chicken",
                           Description ="Steamed chicken with herbs",
                            StandardPrice=40M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "KungPao Chicken",
                           Description ="Spicy sitr-fried chicken with peanuts",
                            StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "Chicken Curry",
                           Description ="Chicken stewed in onion and tomato-based sauce with lots of spices",
                            StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "Bakuteh",
                           Description ="Pork-rib dish cooked in peppery broth",
                            StandardPrice=40M,
                           CategoryID =categories.Single( c => c.Name == "Meat").Id
                          },
                new Dish { Name = "Cereal Butter Prawn",
                           Description ="Fried prawn with cereal and melted butter",
                            StandardPrice=40M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "Chili Crab",
                           Description ="Stir fried mud crab in tomato and chili based sauce",
                            StandardPrice=60M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "Fried Fish",
                           Description ="Homemade fried fish with soy sauce",
                            StandardPrice=40M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "Shrimp Dumplings",
                           Description ="Traditional chinese snack made from wheat starch and shrimp",
                           StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "Steamed Crab",
                          Description ="Steamed mudcrab with egg and ginger",
                            StandardPrice=60M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "Steamed Fish",
                           Description ="Cantonese steamed fish with ginger",
                           StandardPrice=40M,
                           CategoryID =categories.Single( c => c.Name == "Seafood").Id
                          },
                new Dish { Name = "White Radish Soup",
                           Description ="Detoxifying radish soup with red dates",
                           StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },
                new Dish { Name = "Seaweed Soup",
                           Description ="Seaweed soup with homemade pork ball",
                           StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },
                new Dish { Name = "Lotus Root Soup",
                           Description ="Lotus root soup with pork ribs and peanut",
                           StandardPrice=30M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },
                new Dish { Name = "Oyster Soup",
                           Description ="Chinese oyster soup with potato",
                           StandardPrice=35M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },
                new Dish { Name = "Clam Soup",
                           Description ="Fresh clam soup with ginger",
                           StandardPrice=35M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },
                 new Dish { Name = "Bittergourd Soup",
                           Description ="Detoxifying bittergourd soup with pork ribs",
                           StandardPrice=35M,
                           CategoryID =categories.Single( c => c.Name == "Soup").Id
                          },

            };
            dishes.ForEach(c => context.Dishes.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();


            var images = new List<DishImage>
            {
                new DishImage {FileName="Bakuteh.jpg" },
                new DishImage {FileName="bittergourd.jpg" },
                new DishImage {FileName="eggplant.jpg" },
                new DishImage {FileName="brocolli.jpg" },
                new DishImage {FileName="prawn.jpg" },
                new DishImage {FileName="chilicrab.jpg" },
                new DishImage {FileName="clamsoup.jpg" },
                new DishImage {FileName="currychicken.jpg" },
                new DishImage {FileName="friedfish.jpg" },
                new DishImage {FileName="herbalchicken.jpg" },
                new DishImage {FileName="kungpao.jpg" },
                new DishImage {FileName="lotusroot.jpg" },
                new DishImage {FileName="mapotofu.jpg" },
                new DishImage {FileName="oyster.jpg" },
                new DishImage {FileName="redpork.jpg" },
                new DishImage {FileName="seaweed.jpg" },
                new DishImage {FileName="dumpling.jpg" },
                new DishImage {FileName="crab.jpg" },
                new DishImage {FileName="fish.jpg" },
                new DishImage {FileName="greenveggie.jpg" },
                new DishImage {FileName="mushroom.jpg" },
                new DishImage {FileName="sweetpork.jpg" },
                new DishImage {FileName="springrolls.jpg" },
                new DishImage {FileName="whiteradish.jpg" },
            };

            images.ForEach(c => context.DishImages.AddOrUpdate(p => p.FileName, c));
            context.SaveChanges();

            var imageMappings = new List<DishImageMapping>
            {
                new DishImageMapping { DishImageID= images.Single(i => i.FileName == "Bakuteh.jpg").ID,
                    DishID =dishes.Single( c=> c.Name == "Bakuteh").DishID,
                    ImageNumber = 0 },

                 new DishImageMapping { DishImageID= images.Single(i => i.FileName =="bittergourd.jpg").ID,
                     DishID =dishes.Single( c=> c.Name == "Bittergourd Soup").DishID,
                    ImageNumber = 0 },

                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName == "eggplant.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Braised Eggplant").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="brocolli.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Brocolli with Garlic").DishID,
                    ImageNumber = 0
                },
                    new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="prawn.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Cereal Butter Prawn").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="chilicrab.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Chili Crab").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="clamsoup.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Clam Soup").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName == "currychicken.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Chicken Curry").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="friedfish.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Fried Fish").DishID,
                    ImageNumber = 0
                },
                 new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="herbalchicken.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Herbal Chicken").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName == "kungpao.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "KungPao Chicken").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName =="lotusroot.jpg").ID,
                    DishID =dishes.Single( c=> c.Name == "Lotus Root Soup").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "mapotofu.jpg").ID, DishID =dishes.Single( c=> c.Name == "Mapo Tofu").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "oyster.jpg").ID, DishID =dishes.Single( c=> c.Name == "Oyster Soup").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "redpork.jpg").ID, DishID =dishes.Single( c=> c.Name == "Red-fried Pork").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "seaweed.jpg").ID, DishID =dishes.Single( c=> c.Name == "Seaweed Soup").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "dumpling.jpg").ID, DishID =dishes.Single( c=> c.Name == "Shrimp Dumplings").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "crab.jpg").ID, DishID =dishes.Single( c=> c.Name == "Steamed Crab").DishID,
                    ImageNumber = 0 },
                new DishImageMapping { DishImageID= images.Single(i => i.FileName ==
                    "fish.jpg").ID, DishID =dishes.Single( c=> c.Name == "Steamed Fish").DishID,
                    ImageNumber = 0 },

                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="greenveggie.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Green Veggie").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="mushroom.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Mushroom Delight").DishID,
                    ImageNumber = 0
                },

                 new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName =="sweetpork.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Sweet Sour Pork").DishID,
                    ImageNumber = 0
                },

                  new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName == "springrolls.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "Veggie Spring Rolls").DishID,
                    ImageNumber = 0
                },
                new DishImageMapping
                {
                    DishImageID = images.Single(i => i.FileName == "whiteradish.jpg").ID,
                    DishID = dishes.Single(c => c.Name == "White Radish Soup").DishID,
                    ImageNumber = 0
                },
            };
            imageMappings.ForEach(c => context.DishImageMappings.AddOrUpdate(im => im.DishImageID, c));
            context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            const string name = "owner@restaurant.com";
            const string password = "passW0rd!";
            const string roleName = "Owner";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name,

                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }

            //Create users role
            const string userRoleName = "Users";
            role = roleManager.FindByName(userRoleName);
            if (role == null)
            {
                role = new IdentityRole(userRoleName);
                var roleresult = roleManager.Create(role);
            }
        }
    }
}
