using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalForum.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Description", "Family", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Bears are carnivoran mammals of the family Ursidae. They are classified as caniforms, or doglike carnivorans. Although only eight species of bears are extant, they are widespread, appearing in a wide variety of habitats throughout the Northern Hemisphere and partially in the Southern Hemisphere. Bears are found on the continents of North America, South America, Europe, and Asia. Common characteristics of modern bears include large bodies with stocky legs, long snouts, small rounded ears, shaggy hair, plantigrade paws with five nonretractile claws, and short tails.", "Ursidae", "https://upload.wikimedia.org/wikipedia/commons/9/9e/Ours_brun_parcanimalierpyrenees_1.jpg", "Bear" },
                    { 2, "The wild boar, also known as the wild swine,common wild pig,Eurasian wild pig,or simply wild pig,is a suid native to much of Eurasia and North Africa, and has been introduced to the Americas and Oceania. The species is now one of the widest-ranging mammals in the world, as well as the most widespread suiform.It has been assessed as least concern on the IUCN Red List due to its wide range, high numbers, and adaptability to a diversity of habitats.It has become an invasive species in part of its introduced range.", "Suidae", "https://upload.wikimedia.org/wikipedia/commons/d/d2/Wildschwein%2C_N%C3%A4he_Pulverstampftor_%28cropped%29.jpg", "Wild boar" },
                    { 3, "A deer or true deer is a hoofed ruminant mammal of the family Cervidae. The two main groups of deer are the Cervinae, including muntjac, elk, red deer, and fallow deer; and the Capreolinae, including reindeer, white-tailed deer, roe deer, and moose. Male deer of all species, as well as female reindeer, grow and shed new antlers each year. In this, they differ from permanently horned antelope, which are part of a different family (Bovidae) within the same order of even-toed ungulates.", "Cervidae", "https://www.arlingtonva.us/files/sharedassets/public/environment/images/deer.jpg?dimension=pageimagefullwidth&w=992", "Deer" },
                    { 4, "Woodpeckers are part of the bird family Picidae, which also includes the piculets, wrynecks and sapsuckers.Members of this family are found worldwide, except for Australia, New Guinea, New Zealand, Madagascar and the extreme polar regions. Most species live in forests or woodland habitats, although a few species are known that live in treeless areas, such as rocky hillsides and deserts, and the Gila woodpecker specialises in exploiting cacti.", "Picidae", "https://upload.wikimedia.org/wikipedia/commons/6/65/Woodpecker_20040529_151837_1c_cropped.JPG", "Woodpecker" },
                    { 5, "Vipera ammodytes (other common names include horned viper, long-nosed viper, nose-horned viper, sand viper) is a viper species found in southern Europe, mainly northern Italy, the Balkans, and parts of Asia Minor. Like all other vipers, it is venomous. It is reputed to be the most dangerous of the European vipers due to its large size, long fangs (up to 13 mm) and high venom toxicity.The specific name, ammodytes, is derived from the Greek words ammos, and dutes or diver, despite its preference for rocky habitats.", "Viperidae", "https://upload.wikimedia.org/wikipedia/commons/3/35/Vipera-ammodytes-ruffoi-weiblich.jpg", "Viper" },
                    { 6, "Squirrels are members of the family Sciuridae, a family that includes small or medium-size rodents. The squirrel family includes tree squirrels, ground squirrels (including chipmunks and prairie dogs, among others), and flying squirrels. Squirrels are indigenous to the Americas, Eurasia, and Africa, and were introduced by humans to Australia.The earliest known fossilized squirrels date from the Eocene epoch, and among other living rodent families, the squirrels are most closely related to the mountain beaver and to the dormice.", "Sciuridae", "https://media.npr.org/assets/img/2017/04/25/istock-115796521-fcf434f36d3d0865301cdcb9c996cfd80578ca99-s900-c85.webp", "Squirrel" }
                });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "The European beech (Fagus sylvatica) is the most commonly cultivated, although few important differences are seen between species aside from detail elements such as leaf shape. The leaves of beech trees are entire or sparsely toothed, from 5–15 centimetres (2–6 inches) long and 4–10 cm (2–4 in) broad. Beeches are monoecious, bearing both male and female flowers on the same plant. The small flowers are unisexual, the female flowers borne in pairs, the male flowers wind-pollinating catkins.", "https://www.thoughtco.com/thmb/XGPqdHiE66jyy59ViT0C6nVQHlA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Fagus_grandifolia_beech_leaves_close1-58f164123df78cd3fc77b2c4.jpg", "Beech" },
                    { 2, "Juglans regia is a large deciduous tree, attaining heights of 25–35 metres (80–120 feet), and a trunk up to 2 m (6 ft) in diameter, commonly with a short trunk and broad crown.The bark is smooth, olive-brown when young and silvery-grey on older branches, and features scattered broad fissures with a rougher texture. Like all walnuts, the pith of the twigs contains air spaces; this chambered pith is brownish in color. The leaves are alternately arranged, 25–40 cm (10 to 16 in) long.", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG", "Juglans regia" },
                    { 3, "Willows all have abundant watery bark sap, which is heavily charged with salicylic acid, soft, usually pliant, tough wood, slender branches, and large, fibrous, often stoloniferous roots. The roots are remarkable for their toughness, size, and tenacity to live, and roots readily sprout from aerial parts of the plant.", "https://upload.wikimedia.org/wikipedia/commons/0/00/Salix_alba_Morton.jpg", "Willow" },
                    { 4, "The chestnuts are the deciduous trees and shrubs in the genus Castanea, in the beech family Fagaceae. They are native to temperate regions of the Northern Hemisphere.The name also refers to the edible nuts they produce.", "https://upload.wikimedia.org/wikipedia/commons/2/2c/Ch%C3%A2taignier_120807_1.jpg", "Chestnut" },
                    { 5, "The fig is the edible fruit of Ficus carica, a species of small tree in the flowering plant family Moraceae, native to the Mediterranean region, together with western and southern Asia. It has been cultivated since ancient times and is now widely grown throughout the world. Ficus carica is the type species of the genus Ficus, containing over 800 tropical and subtropical plant species.", "https://www.bibleplaces.com/wp-content/uploads/2021/01/Fig-tree-Umm-al-Hedamus-tb060403141.jpg", "A fig tree" },
                    { 6, "A pine is any conifer tree or shrub in the genus Pinus of the family Pinaceae. Pinus is the sole genus in the subfamily Pinoideae. The World Flora Online created by the Royal Botanic Gardens, Kew and Missouri Botanical Garden accepts 187 species names of pines as current, together with more synonyms.The American Conifer Society (ACS) and the Royal Horticultural Society accept 121 species. Pines are commonly found in the Northern Hemisphere.", "https://upload.wikimedia.org/wikipedia/commons/c/ca/Pinus_kesiya_Binga.jpg", "Pine" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
