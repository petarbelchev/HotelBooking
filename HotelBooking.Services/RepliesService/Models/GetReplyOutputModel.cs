﻿using HotelBooking.Services.SharedModels;
using HotelBooking.Services.UsersService.Models;

namespace HotelBooking.Services.RepliesService.Models;

public class GetReplyOutputModel
{
    public int Id { get; set; }

    public string ReplyContent { get; set; } = null!;

    public BaseUserInfoOutputModel Author { get; set; } = null!;

    public AvRatingOutputModel Ratings { get; set; } = null!;

	public DateTime CreatedOnUtc { get; set; }
}