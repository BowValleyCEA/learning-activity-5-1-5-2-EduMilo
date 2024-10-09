
using System.Text;

namespace game1401_la_5
{
    internal class POSSystem
    {
        List<Video> AllVideos;
        List<Customer> AllCustomers;

        public POSSystem()
        {
            AllVideos = new List<Video>();
            AllCustomers = new List<Customer>();
        }
        
        //effectively the main function of the system
        public void Run()
        {
            PromptChoice();
        }

        private void PromptChoice()
        {

            Console.WriteLine("What do you wanna do?");
            Console.WriteLine("1 - Add Customer");
            Console.WriteLine("2 - Add Video");
            Console.WriteLine("3 - Display Inventory");
            Console.WriteLine("4 - Rent Tape");
            Console.WriteLine("5 - Return Tape");
            Console.WriteLine("6 - Show Customer's Tapes");
            Console.WriteLine("or enter NOTHING to close the app.");
            string input;
            int choice;

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out choice) || choice > 6 || choice < 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input! try again.");
                    Console.Clear();
                    continue;
                }
            }

            //choice menu
            switch (choice)
            {
                case 1:
                    PromptAddCustomer();
                    break;
                case 2:
                    PromptAddVideo();
                    break;
                case 3:
                    DisplayInventory();
                    break;
                case 4:
                    PromptRent();
                    break;
                case 5:
                    PromptReturn();
                    break;
                case 6:
                    PromptCustomerInfo();
                    break;
            }
        }
            
        private void PromptAddVideo() 
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Video");
            string videoName = Console.ReadLine();
            Console.WriteLine("Enter it's Genre");
            string videoGenre = Console.ReadLine();
            Console.WriteLine("Enter it's duration (in minutes)");
            string videoDurationStr;
            int videoDuration;
            while (true)
            {
                videoDurationStr = Console.ReadLine();
                if (int.TryParse(videoDurationStr, out videoDuration))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid duration (in minutes)");
                }
            }

            AddVideoToList(videoName, videoGenre, videoDuration);
            Console.WriteLine("Success! Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();

        }

        private void PromptAddCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Customer");
            string customerName = Console.ReadLine();
            AddCustomerToList(customerName);
            Console.WriteLine("Success! Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();
        }

        private void PromptRent()
        {
            Console.Clear();
            Console.WriteLine(CustomerNamesAndIdStr());
            Console.WriteLine("Enter the ID of the Customer");
            int customerId;
            int videoId;
            if (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Customer ID must be a number!");
            } else
            {
                Console.WriteLine(AvailableMoviesStr());
                Console.WriteLine("Enter the ID of the Video");
                if (!int.TryParse(Console.ReadLine(), out videoId))
                {
                    Console.WriteLine("Video ID must be a number!");
                }
                else
                {
                    RentVideo(customerId, videoId);
                }
            }
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();

        }

        private void PromptReturn()
        {
            Console.Clear();
            Console.WriteLine(RentedMoviesStr());
            Console.WriteLine("Enter the ID of the Video");
            int videoId;
            if (!int.TryParse(Console.ReadLine(), out videoId))
            {
                Console.WriteLine("Customer ID must be a number!");
            }
            else
            {
                ReturnVideo(videoId);
            }
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();

        }

        private void PromptCustomerInfo()
        {
            Console.Clear();
            Console.WriteLine(CustomerNamesAndIdStr());
            Console.WriteLine("Enter the ID of the Customer");
            int customerId;
            if (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Customer ID must be a number!");
            }
            else
            {
                if (IsCustomerValid(customerId))
                {
                    Console.WriteLine(CustomerTapesStr(customerId));
                } else
                {
                    Console.WriteLine("Customer does not exist!");
                }

            }
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();
        }
        private void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine(AllVideosStatusesStr());
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();
        }
        private void AddVideoToList(string name, string genre, int duration)
        {
            //id is set to the current amount of videos.
            AllVideos.Add(new Video(name, AllVideos.Count, genre, duration));
        }

        private void AddCustomerToList(string name)
        {
            AllCustomers.Add(new Customer(name, AllCustomers.Count));
        }

        //Strings for prompts 
        private string AllVideosStatusesStr()
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

        private string AvailableMoviesStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Available Videos:");
            foreach (Video i in AllVideos)
            {
                if (!i.IsRented())
                {
                    stringBuilder.AppendLine($"Name: {i.GetName()} ID: {i.GetId()} ");
                }
            }
            return stringBuilder.ToString();
        }

        private string RentedMoviesStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Currently Rented Videos:");
            foreach (Video i in AllVideos)
            {
                if (i.IsRented())
                {
                    stringBuilder.AppendLine($"Name: {i.GetName()} ID: {i.GetId()} ");
                }
            }
            return stringBuilder.ToString();
        }

        private string CustomerNamesAndIdStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Customers:");
            foreach(Customer i in AllCustomers)
            {
                stringBuilder.AppendLine(i.GetName() + "| ID: " + i.GetId());
            }
            return stringBuilder.ToString();
        }

        private string CustomerTapesStr(int id)
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
        //checks if video exists 
        private bool IsVideoValid(int id)
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
        
        private bool IsCustomerValid(int id)
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

        private string RentedByStr(int id)
        {
            //look through all customers to see who has it in their RentedList
            foreach (Customer i in AllCustomers)
            {
                if (i.GetRentedVideos().Contains(AllVideos[id]))
                {
                    return($"Rented by " +
                        $"Customer {i.GetName()} (ID: {i.GetId()})");
                }
            }
            return "";

        }

        private void ReturnVideo(int id)
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
        }

        private void RentVideo(int videoId, int customerId)
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

    }
}
