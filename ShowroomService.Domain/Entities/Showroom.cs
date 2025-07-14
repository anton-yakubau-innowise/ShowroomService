using ShowroomService.Domain.Common;
using ShowroomService.Domain.Enums;

namespace ShowroomService.Domain.Entities
{
    public class Showroom
    {
        public Guid Id { get; private set; }
        public string? Alias { get; private set; }
        public string Address { get; private set; } = null!;
        public string City { get; private set; } = null!;
        public string Country { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string OperatingHours { get; private set; } = null!;
        public ShowroomStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private Showroom()
        {
        }

        public static Showroom CreateShowroom(
            string address,
            string city,
            string country,
            string phone,
            string? alias = null,
            string? operatingHours = null,
            ShowroomStatus? status = null)
        {
            Guard.AgainstNullOrWhiteSpace(address, nameof(address));
            Guard.AgainstNullOrWhiteSpace(city, nameof(city));
            Guard.AgainstNullOrWhiteSpace(country, nameof(country));
            Guard.AgainstNullOrWhiteSpace(phone, nameof(phone));

            return new Showroom
            {
                Id = Guid.NewGuid(),
                Alias = alias,
                Address = address,
                City = city,
                Country = country,
                PhoneNumber = phone,
                Status = status ?? ShowroomStatus.Closed,
                OperatingHours = operatingHours ?? "9:00 AM - 7:00 PM",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateDetails(string? alias = null, string? phone = null, string? address = null, string? city = null, string? country = null)
        {
            if (!string.IsNullOrWhiteSpace(alias))
                Alias = alias;

            if (!string.IsNullOrWhiteSpace(phone))
                PhoneNumber = phone;

            if (!string.IsNullOrWhiteSpace(address))
                Address = address;

            if (!string.IsNullOrWhiteSpace(city))
                City = city;  

            if (!string.IsNullOrWhiteSpace(country))
                Country = country;

            SetUpdated();
        }

        public void Open()
        {
            if (Status == ShowroomStatus.Open)
                throw new InvalidOperationException("Showroom is already open.");
            Status = ShowroomStatus.Open;
            SetUpdated();
        }

        public void Close()
        {
            if (Status == ShowroomStatus.Closed)
                throw new InvalidOperationException("Showroom is already closed.");
            Status = ShowroomStatus.Closed;
            SetUpdated();
        }

        public void StartRenovation()
        {
            if (Status == ShowroomStatus.Open)
                throw new InvalidOperationException("Cannot start renovation on an open showroom. Please close it first.");
            Status = ShowroomStatus.UnderRenovation;
            SetUpdated();
        }

        public void SetOperatingHours(string hours)
        {
            Guard.AgainstNullOrWhiteSpace(hours, nameof(hours));

            OperatingHours = hours;
            SetUpdated();
        }

        private void SetUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}