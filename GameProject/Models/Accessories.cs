namespace GameProject.Models
{
    public class Accessories
    {
        public Accessories(Accessories accessories)
        {
            Shoe = accessories.Shoe;
            Glove = accessories.Glove;
            Clothe = accessories.Clothe;
            Hat = accessories.Hat;
            Pant = accessories.Pant;
        }
        public Accessories(string shoe, string glove, string clothe, string hat, string pant)
        {
            Shoe = shoe;
            Glove = glove;
            Clothe = clothe;
            Hat = hat;
            Pant = pant;
        }

        public string Shoe { get; set; }
        public string Glove { get; set; }
        public string Clothe { get; set; }
        public string Hat { get; set; }
        public string Pant { get; set; }
    }
}
