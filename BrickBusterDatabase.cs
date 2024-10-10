
using System.Text;

namespace game1401_la_5
{
    internal class BrickBusterDatabase
    {
        private List<Video> AllVideos;
        private List<Customer> AllCustomers;

        public BrickBusterDatabase()
        {
            AllVideos = new List<Video>();
            AllCustomers = new List<Customer>();
        }
        
        //Strings for prompts 
        public string AllVideosStatusesStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("All Videos:");
            foreach(Video i in AllVideos)
            {
                stringBuilder.AppendLine($"{i.GetName()} |ID: {i.GetId()} |Duration: {i.GetDuration()}");
                if (i.IsRented())
                {
                    stringBuilder.AppendLine($"Time Rented: {i.StrHowLongRented()}");
                    stringBuilder.AppendLine(RentedByStr(i.GetId()));
                }

            }
            return stringBuilder.ToString();
        }
        public string AvailableMoviesStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Available Videos:");
            foreach (Video i in AllVideos)
            {
                if (!i.IsRented())
                {
                    stringBuilder.AppendLine($"Name: {i.GetName()}| ID: {i.GetId()} ");
                }
            }
            return stringBuilder.ToString();
        }
        public string RentedMoviesStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Currently Rented Videos:");
            foreach (Video i in AllVideos)
            {
                if (i.IsRented())
                {
                    stringBuilder.AppendLine($"Name: {i.GetName()}| ID: {i.GetId()} ");
                }
            }
            return stringBuilder.ToString();
        }
        public string CustomerNamesAndIdStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Customers:");
            foreach(Customer i in AllCustomers)
            {
                stringBuilder.AppendLine(i.GetName() + "| ID: " + i.GetId());
            }
            return stringBuilder.ToString();
        }
        public string CustomerTapesStr(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            Customer currCustomer = AllCustomers[id];
            List<Video> rentedVideosList = currCustomer.GetRentedVideos();
            List<Video> rentHistoryList = currCustomer.GetVideoHistory();

            stringBuilder.AppendLine("Currently rented videos:");
            foreach (Video i in rentedVideosList)
            {
                stringBuilder.AppendLine(i.GetName() + "(ID: " + i.GetId() + ")");
            }

            stringBuilder.AppendLine("Previously rented videos:");
            foreach (Video i in rentHistoryList)
            {
                stringBuilder.AppendLine(i.GetName() + "(ID: " + i.GetId() + ")");
            }

            return stringBuilder.ToString();
        }
        public string RentedByStr(int id)
        {
            //look through all customers to see who has it in their RentedList
            foreach (Customer i in AllCustomers)
            {
                if (i.GetRentedVideos().Contains(AllVideos[id]))
                {
                    return ($"Rented by " +
                        $"Customer {i.GetName()} (ID: {i.GetId()})");
                }
            }
            return "";

        }

        //validity checkers
        public bool IsVideoValid(int id)
        {
            foreach(Video i in AllVideos)
            {
                if(i.GetId() == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCustomerValid(int id)
        {
            foreach(Customer i in AllCustomers)
            {
                if (i.GetId() == id)
                {
                    return true;
                }
            }
            return false;
        }

        //functions
        public void ReturnVideo(int id)
        {
            if (!IsVideoValid(id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }
            //make sure video is rented
            if (AllVideos[id].IsRented())
            {
                //make sure the customer object returns their tape.
                foreach (Customer i in AllCustomers)
                {
                    if (i.GetRentedVideos().Contains(AllVideos[id]))
                    {
                        i.ReturnVideo(AllVideos[id]);
                    }
                }
                //make sure the video is returned
                AllVideos[id].Return();
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed to return video!");
            }
        }
        public void RentVideo(int videoId, int customerId)
        {
            if (!IsVideoValid(videoId))
            {
                Console.WriteLine("Invalid Video ID!");
                return;
            }
            if (!IsCustomerValid(customerId))
            {
                Console.WriteLine("Invalid Customer ID!");
                return;
            }

            AllVideos[videoId].Rent();
            AllCustomers[customerId].RentVideo(AllVideos[videoId]);
            Console.WriteLine("Success!");
        }
        public void AddVideoToList(string name, string genre, int duration)
        {
            //id is set to the current amount of videos.
            AllVideos.Add(new Video(name, AllVideos.Count, genre, duration));
        }
        public void AddCustomerToList(string name)
        {
            AllCustomers.Add(new Customer(name, AllCustomers.Count));
        }

    }
}
