
namespace game1401_la_5
{
    internal class Video
    {
        private String _name;
        private int _id;
        private string _genre;
        private int _duration;
        private DateTime _timeRented;
        private bool _isRented;

        public Video(string name, int id, string genre, int duration)
        {
            _name = name;
            _id = id;
            _genre = genre;
            _duration = duration;
            _isRented = false;
        }

        //getters
        public string GetName()
        {
            return _name;
        }
        public int GetId()
        {
            return _id;
        }
        public string GetGenre()
        {
            return _genre;
        }
        public int GetDuration()
        {
            return _duration;
        }

        //the videotape does not need to know who rented it, but it DOES need to keep track of whether it's currently rented or not.
        //It also needs to know the time it was rented.
        public void Rent()
        {
            _isRented = true;
            _timeRented = DateTime.Now;
        }

        public void Return()
        {
            _isRented = false;
        }

        public bool IsRented()
        {
            return _isRented;
        }

        public string StrHowLongRented()
        {
            if( _isRented)
            {
                TimeSpan timeSpan = DateTime.Now - _timeRented;
                return(timeSpan.ToString("c"));
            } else
            {
                return("N/A");
            }
            
        }
    }


}
