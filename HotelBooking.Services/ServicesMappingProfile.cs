﻿using AutoMapper;
using HotelBooking.Data.Entities;
using HotelBooking.Services.BookingsService.Models;
using HotelBooking.Services.CommentsService.Models;
using HotelBooking.Services.HotelsService.Models;
using HotelBooking.Services.RatingsService.Models;
using HotelBooking.Services.RepliesService.Models;
using HotelBooking.Services.RoomsService.Models;
using HotelBooking.Services.SharedModels;
using HotelBooking.Services.UsersService.Models;
using System.Linq.Expressions;

namespace HotelBooking.Services;

public class ServicesMappingProfile : Profile
{
	public ServicesMappingProfile()
	{
		CreateMap<CreateUserInputModel, ApplicationUser>();
		CreateMap<UpdateUserModel, ApplicationUser>();
		CreateMap<ApplicationUser, BaseUserInfoOutputModel>();
		CreateMap<ApplicationUser, TokenOutputModel>();

		CreateMap<ApplicationUser, GetUserOutputModel>()
			.ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments.Count()))
			.ForMember(d => d.FavoriteHotels, o => o.MapFrom(s => s.FavoriteHotels.Count()))
			.ForMember(d => d.OwnedHotels, o => o.MapFrom(s => s.OwnedHotels.Count()))
			.ForMember(d => d.Ratings, o => o.MapFrom(s => s.Ratings.Count()))
			.ForMember(d => d.Replies, o => o.MapFrom(s => s.Replies.Count()))
			.ForMember(d => d.Trips, o => o.MapFrom(s => s.Trips.Count()));

		CreateMap<CreateUpdateRoomInputModel, Room>();
		CreateMap<Room, CreateGetUpdateRoomOutputModel>();
		CreateMap<UpdateHotelModel, Hotel>();
		CreateMap<CreateHotelInputModel, Hotel>();
		CreateMap<City, GetCityOutputModel>();

		CreateMap<ICollection<Rating>, AvRatingOutputModel>()
			.ForMember(d => d.Rating, o => o.MapFrom(s => s.Count != 0
				? s.Sum(rating => rating.Value) / (float)s.Count
				: 0))
			.ForMember(d => d.RatingsCount, o => o.MapFrom(s => s.Count));

		int userId = default;
		CreateMap<Hotel, BaseHotelInfoOutputModel>()
			.ForMember(d => d.IsUserFavoriteHotel, o => o
				.MapFrom(s => s.UsersWhoFavorited.Any(user => user.Id == userId)));
		CreateMap<Hotel, GetHotelInfoOutputModel>()
			.IncludeBase<Hotel, BaseHotelInfoOutputModel>();
		CreateMap<Hotel, GetHotelWithOwnerInfoOutputModel>()
			.IncludeBase<Hotel, GetHotelInfoOutputModel>();

		Expression<Func<Room, bool>>? isAvailableRoom = default;
		CreateMap<Hotel, GetAvailableHotelRoomsOutputModel>()
			.ForMember(d => d.AvailableRooms, o => o
				.MapFrom(s => s.Rooms.AsQueryable().Where(isAvailableRoom!)));

		CreateMap<Comment, GetCommentOutputModel>();
		CreateMap<Rating, CreateRatingOutputModel>();
		CreateMap<Reply, GetReplyOutputModel>();
		CreateMap<Booking, CreateGetBookingOutputModel>();
	}
}
