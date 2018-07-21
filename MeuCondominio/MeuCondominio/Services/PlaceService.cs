using MeuCondominio.Models;
using System.Collections.Generic;

namespace MeuCondominio.Services
{
    public class PlaceService
    {
        public static MvvmHelpers.ObservableRangeCollection<Place> GetPlaces()
        {
            var lstPlaces = new MvvmHelpers.ObservableRangeCollection<Place>();
            var lstBlocks = new List<string>() { "A", "B" };
            int iPlacePerFloor = 4;
            int iFloors = 12;

            foreach (string block in lstBlocks)
            {
                for (int floor = 1; floor <= iFloors; floor++)
                {
                    for (int place = 1; place <= iPlacePerFloor; place++)
                    {
                        lstPlaces.Add(new Place()
                        {
                            Block = block,
                            Number = (floor * 10 + place).ToString(),
                            IsSelected = false
                        });
                    }
                }
            }

            return lstPlaces;
        }

    }
}
