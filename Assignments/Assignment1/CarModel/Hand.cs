using System.Collections.Generic;
using System.Linq;

namespace DNP2.Assignment1.CarModel
{
    public class Hand
    {
        public IList<Car> Cars { get; set; } = new List<Car>();

        public IList<Car> FindCarsByMaxSpeed(int speed)
        {
            return Cars.Where(car => car.MaxSpeed > speed).ToList();
        }
    }
}