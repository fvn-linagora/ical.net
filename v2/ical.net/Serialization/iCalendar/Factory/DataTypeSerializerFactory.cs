﻿using System;
using ical.net.DataTypes;
using ical.net.Interfaces.DataTypes;
using ical.net.Interfaces.Serialization;
using ical.net.Interfaces.Serialization.Factory;
using ical.net.Serialization.iCalendar.Serializers.DataTypes;
using ical.net.Serialization.iCalendar.Serializers.Other;

namespace ical.net.Serialization.iCalendar.Factory
{
    public class DataTypeSerializerFactory : ISerializerFactory
    {
        /// <summary>
        /// Returns a serializer that can be used to serialize and object
        /// of type <paramref name="objectType"/>.
        /// <note>
        ///     TODO: Add support for caching.
        /// </note>
        /// </summary>
        /// <param name="objectType">The type of object to be serialized.</param>
        /// <param name="ctx">The serialization context.</param>
        public virtual ISerializer Build(Type objectType, SerializationContext ctx)
        {
            if (objectType != null)
            {
                ISerializer s;

                if (typeof (IAttachment).IsAssignableFrom(objectType))
                {
                    s = new AttachmentSerializer();
                }
                else if (typeof (Attendee).IsAssignableFrom(objectType))
                {
                    s = new AttendeeSerializer();
                }
                else if (typeof (IDateTime).IsAssignableFrom(objectType))
                {
                    s = new DateTimeSerializer();
                }
                else if (typeof (FreeBusyEntry).IsAssignableFrom(objectType))
                {
                    s = new FreeBusyEntrySerializer();
                }
                else if (typeof (IGeographicLocation).IsAssignableFrom(objectType))
                {
                    s = new GeographicLocationSerializer();
                }
                else if (typeof (Organizer).IsAssignableFrom(objectType))
                {
                    s = new OrganizerSerializer();
                }
                else if (typeof (IPeriod).IsAssignableFrom(objectType))
                {
                    s = new PeriodSerializer();
                }
                else if (typeof (IPeriodList).IsAssignableFrom(objectType))
                {
                    s = new PeriodListSerializer();
                }
                else if (typeof (IRecurrencePattern).IsAssignableFrom(objectType))
                {
                    s = new RecurrencePatternSerializer();
                }
                else if (typeof (RequestStatus).IsAssignableFrom(objectType))
                {
                    s = new RequestStatusSerializer();
                }
                else if (typeof (StatusCode).IsAssignableFrom(objectType))
                {
                    s = new StatusCodeSerializer();
                }
                else if (typeof (Trigger).IsAssignableFrom(objectType))
                {
                    s = new TriggerSerializer();
                }
                else if (typeof (UtcOffset).IsAssignableFrom(objectType))
                {
                    s = new UtcOffsetSerializer();
                }
                else if (typeof (WeekDay).IsAssignableFrom(objectType))
                {
                    s = new WeekDaySerializer();
                }
                // Default to a string serializer, which simply calls
                // ToString() on the value to serialize it.
                else
                {
                    s = new StringSerializer();
                }

                // Set the serialization context
                s.SerializationContext = ctx;

                return s;
            }
            return null;
        }
    }
}