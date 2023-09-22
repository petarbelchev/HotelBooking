﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelBooking.Common.Constants.EntityValidationConstants;

namespace HotelBooking.Data.Entities;

public class Hotel : RatableEntity
{
	[Required]
	[MaxLength(HotelNameMaxLength)]
	public string Name { get; set; } = null!;

    [Required]
	[ForeignKey(nameof(Owner))]
    public int OwnerId { get; set; }
	public ApplicationUser Owner { get; set; } = null!;

	[Required]
	[MaxLength(HotelNameMaxLength)]
	public string Address { get; set; } = null!;

	[Required]
	[ForeignKey(nameof(City))]
    public int CityId { get; set; }
	public City City { get; set; } = null!;

	[Required]
	[MaxLength(HotelDescriptionMaxLength)]
	public string Description { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

    public ICollection<ApplicationUser> UsersWhoFavorited { get; set; } = new HashSet<ApplicationUser>();

	public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

	public ICollection<Image> Images { get; set; } = new HashSet<Image>();
}
