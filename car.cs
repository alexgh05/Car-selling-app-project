using System;

public class Car
{
	public string make { get; set; }
	public string model { get; set; }
	public string video_director { get; set; }
	public string[] description { get; set; }
	public int hp;
	public string engine_size { get; set; }
	public string fuel { get; set; }
	public string color { get; set; }
	public string gearbox_type { get; set;}
	public string mileage { get; set; }
	public int make_year { get; set; }	
	
	

	public Car(string make, string model, string video_,
		string[] description_, int hp_, string engine_size_,string fuel,
		string color,string gearbox_type,string mileage,int make_year)
	{
		this.make = make;
		this.model = model;
		this.video_director = video_;
		this.description = description_;
		this.hp = hp_;
		this.engine_size = engine_size_;
		this.fuel = fuel;
		this.color = color;
        this.gearbox_type = gearbox_type;
		this.mileage = mileage;
		this.make_year = make_year;
	}

	
}
