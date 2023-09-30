﻿using HotelBooking.Services.SharedModels;

namespace HotelBooking.Services.RoomsService.Models;

public class CreateGetUpdateRoomOutputModel : CreateUpdateRoomInputModel
{
    public int Id { get; set; }

    public MainImageOutputModel? MainImage { get; set; }
}
