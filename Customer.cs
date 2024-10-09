namespace game1401_la_5
{
    internal class Customer
    {
        private String _name;
        private int _id;
        private List<Video> _rentedVideos;
        private List<Video> _videoHistory;

        public Customer(string name, int id)
        {
            _name = name;
            _id = id;
            _rentedVideos = new List<Video>();
            _videoHistory = new List<Video>();
        }

        //good ol getters and setters
        public string GetName()
        {
            return _name;
        }
        public int GetId()
        {
            return _id;
        }

        public List<Video> GetRentedVideos()
        {
            return _rentedVideos;
        }

        public List<Video> GetVideoHistory()
        {
            return _videoHistory;
        }

        public void RentVideo(Video video)
        {
            _rentedVideos.Add(video);
        }

        public void ReturnVideo(Video video)
        {
            if (_rentedVideos.Contains(video))
            {
                _rentedVideos.Remove(video);
                _videoHistory.Add(video);
            }
            else
            {
                Console.WriteLine("That Customer does not have that tape to begin with!");
            }
        }


    }
}
