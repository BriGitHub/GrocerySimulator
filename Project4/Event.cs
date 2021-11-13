///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project4/Project4
//	File Name:         Event.cs
//	Description:       Represents a hypothetical action a person at the supermarket would do
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Brianna Martinson, martinson@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Friday, April 5, 2019
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    enum EVENTTYPE { ENTER, LEAVE };

    /// <summary>
    /// Represents a hypothetical action a person at the supermarket would do
    /// </summary>
    class Event : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
        public int Patron { get; set; }

        /// <summary>
        /// Default Constructor
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Patron = -1;
        }

        /// <summary>
        /// Parametrized Constructor
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="type">The type of event.</param>
        /// <param name="time">The time the event started.</param>
        /// <param name="patron">The patron number.</param>
        public Event(EVENTTYPE type, DateTime time, int patron)
        {
            Type = type;
            Time = time;
            Patron = patron;
        }

        /// <summary>
        /// Converts an Event object to a string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            String str = "";

            str += String.Format("Patron {0} ", Patron.ToString().PadLeft(3));
            str += Type + "'s";
            str += String.Format(" at {0}", Time.ToShortTimeString().PadLeft(8));

            return str;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">The argument is not an Event object</exception>
        public int CompareTo(Object obj)
        {
            if (!(obj is Event))
                throw new ArgumentException("The argument is not an Event object");

            Event e = (Event)obj;
            return (e.Time.CompareTo(Time));
        }

    }
}
