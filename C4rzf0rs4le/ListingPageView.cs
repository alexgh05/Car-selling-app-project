
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4rzf0rs4le
{
    public class ListingPageView : BindableObject
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars_ul
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars_ul));
            }
        }

        public ListingPageView(List<Car>usercars)
        {

            Cars_ul = new ObservableCollection<Car>();
          //  string location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // string vidsFolderPath = Path.Combine(location, "vids");
            foreach (var c4r in usercars) {
                //string videopath = Path.Combine(vidsFolderPath, c4r.video_director);
                Cars_ul.Add(new Car {
                    make =c4r.make,
                    make_year = c4r.make_year,
                    model = c4r.model,
                    mileage = c4r.mileage,
                    phoneNumber = c4r.phoneNumber,
                    username = c4r.username,
                    video_director = c4r.video_director
                    , price = c4r.price
                    ,
                    hp = c4r.hp,
                    color = c4r.color
                });
                     }

                
           
        }


    }
}

