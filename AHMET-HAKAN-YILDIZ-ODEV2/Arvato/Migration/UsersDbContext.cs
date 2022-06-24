using Arvato.Model;

namespace Arvato.Migration
{
    public class UsersDbContext
    {
        public static List<User> Users = new List<User>()
        {
           new User
           {
                Id= 1,
                Name="Hakan",
                Surname="Yıldız",
                TCNU="44929996822",
                Phone="05526580672",
                Mail="teknomanihah@gmail.com",
                date=new DateTime(2022,06,23),
                BootcampId=2,
           },

           new User
           {
                Id= 2,
                Name="Aziz",
                Surname="Salman",
                TCNU="21345354354",
                Phone="05526580672",
                Mail="teknomanihah@gmail.com",
                date=new DateTime(2022,06,23),
                BootcampId=1,
           },

             new User
           {
                Id= 3,
                Name="Can",
                Surname="Bonomo",
                TCNU="01987654321",
                Phone="05526580672",
                Mail="can.bonomo34@icloud.com",
                date=new DateTime(2022,06,23),
                BootcampId=1,
           },
               new User
           {
                Id= 4,
                Name="Mücahid",
                Surname="Eren",
                TCNU="1234567901",
                Phone="05526580672",
                Mail="mucahid_eren_01@windowslive.com",
                date=new DateTime(2022,06,23),
                BootcampId=1,
           }

        };



    }
}
