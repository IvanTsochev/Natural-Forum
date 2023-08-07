namespace NaturalForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class TreeEntityConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.HasData(this.GenerateTrees());
        }

        private Tree[] GenerateTrees()
        {
            ICollection<Tree> trees = new HashSet<Tree>();

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
                Name = "Willow",
                Description = "Willows all have abundant watery bark sap, which is heavily charged with salicylic acid, soft, usually pliant, tough wood, slender branches, and large, fibrous, often stoloniferous roots. The roots are remarkable for their toughness, size, and tenacity to live, and roots readily sprout from aerial parts of the plant.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/00/Salix_alba_Morton.jpg"
            };
            trees.Add(tree);

            tree = new Tree()
            {
                Id = 4,
                Name = "Chestnut",
                Description = "The chestnuts are the deciduous trees and shrubs in the genus Castanea, in the beech family Fagaceae. They are native to temperate regions of the Northern Hemisphere.The name also refers to the edible nuts they produce.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Ch%C3%A2taignier_120807_1.jpg"
            };
            trees.Add(tree);

            tree = new Tree()
            {
                Id = 5,
                Name = "A fig tree",
                Description = "The fig is the edible fruit of Ficus carica, a species of small tree in the flowering plant family Moraceae, native to the Mediterranean region, together with western and southern Asia. It has been cultivated since ancient times and is now widely grown throughout the world. Ficus carica is the type species of the genus Ficus, containing over 800 tropical and subtropical plant species.",
                ImageUrl = "https://www.bibleplaces.com/wp-content/uploads/2021/01/Fig-tree-Umm-al-Hedamus-tb060403141.jpg"
            };
            trees.Add(tree);

            tree = new Tree()
            {
                Id = 6,
                Name = "Pine",
                Description = "A pine is any conifer tree or shrub in the genus Pinus of the family Pinaceae. Pinus is the sole genus in the subfamily Pinoideae. The World Flora Online created by the Royal Botanic Gardens, Kew and Missouri Botanical Garden accepts 187 species names of pines as current, together with more synonyms.The American Conifer Society (ACS) and the Royal Horticultural Society accept 121 species. Pines are commonly found in the Northern Hemisphere.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/ca/Pinus_kesiya_Binga.jpg"
            };
            trees.Add(tree);

            return trees.ToArray();
        }
    }
}
