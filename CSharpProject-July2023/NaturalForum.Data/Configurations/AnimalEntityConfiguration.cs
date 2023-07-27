namespace NaturalForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using NaturalForum.Data.Models;
    public class AnimalEntityConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(this.GenerateAnimals());
        }

        private Animal[] GenerateAnimals()
        {
            ICollection<Animal> animals = new HashSet<Animal>();

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
                ImageUrl = "https://www.arlingtonva.us/files/sharedassets/public/environment/images/deer.jpg?dimension=pageimagefullwidth&w=992"
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Id = 4,
                Name = "Woodpecker",
                Family = "Picidae",
                Description = "Woodpeckers are part of the bird family Picidae, which also includes the piculets, wrynecks and sapsuckers.Members of this family are found worldwide, except for Australia, New Guinea, New Zealand, Madagascar and the extreme polar regions. Most species live in forests or woodland habitats, although a few species are known that live in treeless areas, such as rocky hillsides and deserts, and the Gila woodpecker specialises in exploiting cacti.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/65/Woodpecker_20040529_151837_1c_cropped.JPG"
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Id = 5,
                Name = "Viper",
                Family = "Viperidae",
                Description = "Vipera ammodytes (other common names include horned viper, long-nosed viper, nose-horned viper, sand viper) is a viper species found in southern Europe, mainly northern Italy, the Balkans, and parts of Asia Minor. Like all other vipers, it is venomous. It is reputed to be the most dangerous of the European vipers due to its large size, long fangs (up to 13 mm) and high venom toxicity.The specific name, ammodytes, is derived from the Greek words ammos, and dutes or diver, despite its preference for rocky habitats.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Vipera-ammodytes-ruffoi-weiblich.jpg"
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Id = 6,
                Name = "Squirrel",
                Family = "Sciuridae",
                Description = "Squirrels are members of the family Sciuridae, a family that includes small or medium-size rodents. The squirrel family includes tree squirrels, ground squirrels (including chipmunks and prairie dogs, among others), and flying squirrels. Squirrels are indigenous to the Americas, Eurasia, and Africa, and were introduced by humans to Australia.The earliest known fossilized squirrels date from the Eocene epoch, and among other living rodent families, the squirrels are most closely related to the mountain beaver and to the dormice.",
                ImageUrl = "https://media.npr.org/assets/img/2017/04/25/istock-115796521-fcf434f36d3d0865301cdcb9c996cfd80578ca99-s900-c85.webp"
            };
            animals.Add(animal);


            return animals.ToArray();
        }
    }
}
