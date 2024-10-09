
namespace game1401_la_5
{
    internal class POSSystem
    {

        BrickBusterDatabase brickBusterDB = new BrickBusterDatabase();
        public void Run()
        {
            PromptChoice();
        }

        //frontend prompts
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

            brickBusterDB.AddVideoToList(videoName, videoGenre, videoDuration);
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
            brickBusterDB.AddCustomerToList(customerName);
            Console.WriteLine("Success! Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();
        }
        private void PromptRent()
        {
            Console.Clear();
            Console.WriteLine(brickBusterDB.CustomerNamesAndIdStr());
            Console.WriteLine("Enter the ID of the Customer");
            int customerId;
            int videoId;
            if (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Customer ID must be a number!");
            }
            else
            {
                Console.WriteLine(brickBusterDB.AvailableMoviesStr());
                Console.WriteLine("Enter the ID of the Video");
                if (!int.TryParse(Console.ReadLine(), out videoId))
                {
                    Console.WriteLine("Video ID must be a number!");
                }
                else
                {
                    brickBusterDB.RentVideo(customerId, videoId);
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
            Console.WriteLine(brickBusterDB.RentedMoviesStr());
            Console.WriteLine("Enter the ID of the Video");
            int videoId;
            if (!int.TryParse(Console.ReadLine(), out videoId))
            {
                Console.WriteLine("Customer ID must be a number!");
            }
            else
            {
                brickBusterDB.ReturnVideo(videoId);
            }
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();

        }
        private void PromptCustomerInfo()
        {
            Console.Clear();
            Console.WriteLine(brickBusterDB.CustomerNamesAndIdStr());
            Console.WriteLine("Enter the ID of the Customer");
            int customerId;
            if (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Customer ID must be a number!");
            }
            else
            {
                if (brickBusterDB.IsCustomerValid(customerId))
                {
                    Console.WriteLine(brickBusterDB.CustomerTapesStr(customerId));
                }
                else
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
            Console.WriteLine(brickBusterDB.AllVideosStatusesStr());
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
            Console.Clear();
            PromptChoice();
        }

    }
}
