///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project4/Project4
//	File Name:         IContainer.cs
//	Description:       One of the interfaces for PriorityQueue<T>
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Brianna Martinson, martinson@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Saturday, April 6, 2019
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    /// <summary>
    /// One of the interfaces for PriorityQueue<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T>
    {
        //Remove all objects from the container
        void Clear();

        //Returns true if container is empty
        bool IsEmpty();

        //Returns the number of entries in the container
        int Count { get; set; }
    }
}
