///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project4/Project4
//	File Name:         Customer.cs
//	Description:       Represents a hypothetical person going to the supermarket
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
    /// <summary>
    /// Represents a hypothetical person going to the supermarket
    /// </summary>
    class Customer : IComparable
    {
        private Random r = new Random();

        public TimeSpan totalTime { get; set; }
        private const int MIN_TIME = 120;
        public Event arriveEvent { get; set; }
        public Event leaveEvent { get; set; }
        public int custID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// Default Constructor
        /// </summary>
        public Customer()
        {
            arriveEvent = new Event();
            leaveEvent = new Event();
            double num = NegExp((5.45 * 60) - MIN_TIME);
            totalTime = new TimeSpan(0, 0, (int)num + MIN_TIME);
            custID = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// Parameterized Constructor
        /// </summary>
        /// <param name="arrival">The arrival.</param>
        /// <param name="custNum">The customer number.</param>
        /// <param name="avgTime">The average time.</param>
        public Customer(DateTime arrival, int custNum, double avgTime)
        {
            arriveEvent = new Event(EVENTTYPE.ENTER, arrival, custNum);
            double num = NegExp((avgTime * 60) - MIN_TIME);
            totalTime = new TimeSpan(0, 0, (int)num + MIN_TIME);
            custID = custNum;
        }

        /// <summary>
        /// Generates an integer using the Negative Exponential Distribution (Non-uniform)
        /// </summary>
        /// <param name="ExpectedValue">The double the return is based off</param>
        /// <returns>The generated number</returns>
        private double NegExp(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(r.NextDouble(), Math.E);
        }

        /// <summary>
        /// Generates an integer using the Normal Distribution (Non-uniform)
        /// </summary>
        /// <param name="ExpectedValue">The double the return is based off</param>
        /// <param name="StdDev">The standard deviation being used</param>
        /// <returns>The generated number</returns>
        private double Normal(double ExpectedValue, double StdDev)
        {
            //Using the Box-Muller algorithm
            double R = Math.Sqrt(-2.0 * Math.Log(r.NextDouble()));
            double Theta = 2.0 * Math.PI * r.NextDouble();
            double Value = R * Math.Sin(Theta);
            return ExpectedValue + StdDev * Value;
        }

        /// <summary>
        /// Generates an integer using the Poisson Distribution (Non-uniform)
        /// </summary>
        /// <param name="ExpectValue">The double the return is based off</param>
        /// <returns>The generated number</returns>
        private int Poisson(double ExpectValue)
        {
            double dLimit = -ExpectValue;
            double dSum = Math.Log(r.NextDouble());

            int Count;
            for (Count = 0; dSum > dLimit; Count++)
                dSum += Math.Log(r.NextDouble());

            return Count;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">The argument is not an Customer object</exception>
        public int CompareTo(Object obj)
        {
            if (!(obj is Customer))
                throw new ArgumentException("The argument is not an Customer object");

            Customer e = (Customer)obj;
            return (e.arriveEvent.CompareTo(arriveEvent));
        }
    }
}
