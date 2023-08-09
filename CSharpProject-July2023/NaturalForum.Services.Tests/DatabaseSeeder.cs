namespace NaturalForum.Services.Tests
{
    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using System.Collections.Generic;

    public static class DatabaseSeeder
    {
        public static ICollection<Tree> trees;
        public static void SeedDatabase(NaturalForumDbContext dbContext)
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

            dbContext.AddRange(trees);
        }
    }
}
