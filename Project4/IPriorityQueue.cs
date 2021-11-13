///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project4/Project4
//	File Name:         IPriorityQueue.cs
//	Description:       One of the interfaces for PriorityQueue<T>
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Brianna Martinson, martinson@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Saturday, April 6, 2019
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Project4
{
    /// <summary>
    /// One of the interfaces for PriorityQueue<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Project4.IContainer{T}" />
    public interface IPriorityQueue<T> : IContainer<T>
                               where T : IComparable
    {
        //Inserts item based on its priority
        void Enqueue(T item);

        //Removes first item in the queue
        void Dequeue();

        //Query
        T Peek();
    }
}
