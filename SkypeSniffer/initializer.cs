using SKYPE4COMLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeSniffer
{
    public class Initializer
    {
        static void Main()
        {
            Initializer init = new Initializer();

            init.Initiolize();
        }

        public static Skype Skype { get; private set; }
        IEnumerable<User> friends;
        List<string> favoritesList;
        IEnumerable<User> favoritesUsers;



        //public void SerchUsers(List observedUsers, Skype.Friends.Cast<User>.)
        //{
        //    foreach (var friend in Skype.Friends.Cast<User>())
        //    {
        //        Console.WriteLine(friend.GetCorrectName());
        //    }
        //    Console.ReadKey();

        //    //Skype.OnlineStatus += Skype_OnlineStatus;
        //}




        public void Initiolize()
        {
            Skype = new Skype();
            friends = Skype.Friends.Cast<User>();
            favoritesList = new List<string>() { "salterok", "helen_mav" };
            favoritesUsers = new List<User>();

            Console.WriteLine(GetCorrectNames(friends));
            AddToFavoritesUsers(favoritesList);
            AddToFavoritesUsers("salterok");
            
            AddToFavoritesUsers("helen_mav");
            AddToFavoritesUsers("salterok");

            Console.WriteLine(GetCorrectNames(favoritesUsers));
            //favoritesUsers = friends.Where(user => favoritesList.Contains(user.Handle));
            IEnumerable<String> info = favoritesUsers.Select(user => user.ToInfoString());

            File.AppendAllLines("info.txt", info);


            Console.ReadKey();
        }

        public void AddToFavoritesUsers(string friend)
        {
            var newUsers = friends.Where(user => friend.Contains(user.Handle));


            favoritesUsers = favoritesUsers.Concat(newUsers);

            //favoritesUsers.ToList().Add(friends.Where(user => friend.Contains(user.Handle)));
            //favoritesUsers = friends.Where(user => friend.Contains(user.Handle)));
            // favoritesUsers.ToList().Concat( friends.Where(user => friend.Contains(user.Handle)));
        }


        public void AddToFavoritesUsers(List<string> favoritesList)
        {
           // favoritesUsers.Concat(friends.Where(user => favoritesList.Contains(user.Handle)));
            //favoritesUsers.ToList().Concat(friends.Where(user => favoritesList.Contains(user.Handle)));
        }

        public string GetCorrectNames(IEnumerable<User> friends)
        {
            string corectNames = "";
            foreach (var friend in friends)
            {
                corectNames += friend.GetCorrectName() + "\n";
            }
            return corectNames;
        }

        public string GetCorrectNames(string search)
        {
            string corectNames = "";
            foreach (var friend in friends)
            {
                if(friend.Handle == search)
                corectNames += friend.GetCorrectName() + "\n";
            }
            return corectNames;
        }

    }
}
