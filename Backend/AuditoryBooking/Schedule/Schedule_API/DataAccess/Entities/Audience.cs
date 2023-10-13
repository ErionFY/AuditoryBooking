﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule_API.DataAccess.Entities;

public class Audience
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string? ShortName { get; set; }
    public Building? Building { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}