
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleManagement.Models;
using System;
using System.Collections.Generic;

namespace ScheduleManagement.Tests
{
    [TestClass]
    public class StudentGroupTests
    {
        [TestMethod]
        public void StudentGroup_ShouldBeCreated_WithValidData()
        {
            // Arrange
            var groupName = "Group A";
            var students = new List<string> { "Alice", "Bob", "Charlie" };

            // Act
            var group = new StudentGroup(groupName, students);

            // Assert
            Assert.AreEqual(groupName, group.GroupName, "Group name does not match.");
            CollectionAssert.AreEquivalent(students, group.Students, "Students list does not match.");
        }

        [TestMethod]
        public void StudentGroup_ShouldThrowException_WhenGroupNameIsEmpty()
        {
            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => new StudentGroup("", new List<string>()));
            StringAssert.Contains(exception.Message, "Group name cannot be empty.");
        }
    }
}


