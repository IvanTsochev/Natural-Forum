namespace NaturalForum.Services.Tests
{
    using System;

    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using System.Collections.Generic;

    public static class DatabaseSeeder
    {
        public static ICollection<Tree> trees;
        public static ICollection<Animal> animals;
        public static ICollection<ApplicationUser> applicationUsers;
        public static ICollection<Article> articles;
        public static void SeedTreesInDb(NaturalForumDbContext dbContext)
        {
            trees = new HashSet<Tree>();

            Tree tree;
            
            tree = new Tree()
            {
                Id = 1,
                Name = "Beech",
                Description = "The European beech (Fagus sylvatica) is the most commonly cultivated, although few important differences are seen between species aside from detail elements such as leaf shape. The leaves of beech trees are entire or sparsely toothed, from 5–15 centimetres (2–6 inches) long and 4–10 cm (2–4 in) broad. Beeches are monoecious, bearing both male and female flowers on the same plant. The small flowers are unisexual, the female flowers borne in pairs, the male flowers wind-pollinating catkins.",
                ImageUrl = "https://www.thoughtco.com/thmb/XGPqdHiE66jyy59ViT0C6nVQHlA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Fagus_grandifolia_beech_leaves_close1-58f164123df78cd3fc77b2c4.jpg"
            };
            trees.Add(tree);

            tree = new Tree()
            {
                Id = 2,
                Name = "Juglans regia",
                Description = "Juglans regia is a large deciduous tree, attaining heights of 25–35 metres (80–120 feet), and a trunk up to 2 m (6 ft) in diameter, commonly with a short trunk and broad crown.The bark is smooth, olive-brown when young and silvery-grey on older branches, and features scattered broad fissures with a rougher texture. Like all walnuts, the pith of the twigs contains air spaces; this chambered pith is brownish in color. The leaves are alternately arranged, 25–40 cm (10 to 16 in) long.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG"
            };
            trees.Add(tree);

            tree = new Tree()
            {
                Id = 3,
                Name = "Apple",
                Description = "heights of 25–35 metres (80–120 feet), and a trunk up to 2 m (6 ft) in diameter, commonly with a short trunk and broad crown.The bark is smooth, olive-brown when young and silvery-grey on older branches, and features scattered broad fissures with a rougher texture. Like all walnuts, the pith of the twigs contains air spaces; this chambered pith is brownish in color. The leaves are alternately arranged, 25–40 cm (10 to 16 in) long.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG"
            };
            trees.Add(tree);

            dbContext.Trees.AddRange(trees);
        }

        public static void SeedAnimalsInDb(NaturalForumDbContext dbContext)
        {
            dbContext.Animals.RemoveRange(dbContext.Animals);

            animals = new HashSet<Animal>();

            Animal animal;

            animal = new Animal()
            {
                Id = 1,
                Name = "Bear",
                Family = "Ursidae",
                Description = "Bears are carnivoran mammals of the family Ursidae. They are classified as caniforms, or doglike carnivorans. Although only eight species of bears are extant, they are widespread, appearing in a wide variety of habitats throughout the Northern Hemisphere and partially in the Southern Hemisphere. Bears are found on the continents of North America, South America, Europe, and Asia. Common characteristics of modern bears include large bodies with stocky legs, long snouts, small rounded ears, shaggy hair, plantigrade paws with five nonretractile claws, and short tails.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/Ours_brun_parcanimalierpyrenees_1.jpg"
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Id = 2,
                Name = "Wild boar",
                Family = "Suidae",
                Description = "The wild boar, also known as the wild swine,common wild pig,Eurasian wild pig,or simply wild pig,is a suid native to much of Eurasia and North Africa, and has been introduced to the Americas and Oceania. The species is now one of the widest-ranging mammals in the world, as well as the most widespread suiform.It has been assessed as least concern on the IUCN Red List due to its wide range, high numbers, and adaptability to a diversity of habitats.It has become an invasive species in part of its introduced range.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d2/Wildschwein%2C_N%C3%A4he_Pulverstampftor_%28cropped%29.jpg"
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Id = 3,
                Name = "Deer",
                Family = "Cervidae",
                Description = "A deer or true deer is a hoofed ruminant mammal of the family Cervidae. The two main groups of deer are the Cervinae, including muntjac, elk, red deer, and fallow deer; and the Capreolinae, including reindeer, white-tailed deer, roe deer, and moose. Male deer of all species, as well as female reindeer, grow and shed new antlers each year. In this, they differ from permanently horned antelope, which are part of a different family (Bovidae) within the same order of even-toed ungulates.",
                ImageUrl = "https://www.nyc.gov/assets/wildlifenyc/images/content/pages/Stag_On_A_Hill.jpg"
            };
            animals.Add(animal);

            dbContext.Animals.AddRange(animals);
        }

        public static void SeedArticlesInDb(NaturalForumDbContext dbContext)
        {
            articles = new HashSet<Article>();

            Article article;

            article = new Article()
            {
                Id = 5,
                Title = "Test Article",
                Description = "This description is for test service only xD",
                ImageUrl = "https://5.imimg.com/data5/AK/RA/MY-68428614/apple-1000x1000.jpg",
                CreaterId = Guid.Parse("9A8A430C-2A8D-4DF5-9A83-F200FA8DBF0D")
            };

            articles.Add(article);
            dbContext.Articles.AddRange(article);
            dbContext.SaveChanges();
        }
    }
}
