using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleManagement.Models;
using ScheduleManagement.Services;
using System;
using System.Collections.Generic;

namespace ScheduleManagement.Tests
{
    [TestClass]
    public class ScheduleManagerTests
    {
        [TestMethod]
        public void AddGroup_ShouldAddNewGroup_WhenGroupIsValid()
        {
            // Arrange
            var manager = new ScheduleManager();
            var group = new StudentGroup("Group A", new List<string> { "Alice", "Bob" });

            // Act
            manager.AddGroup(group);

            // Assert
            var groups = manager.GetAllGroups();
            Assert.AreEqual(1, groups.Count);
            Assert.AreEqual("Group A", groups[0].GroupName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddGroup_ShouldThrowException_WhenGroupNameIsNotUnique()
        {
            // Arrange
            var manager = new ScheduleManager();
            var group = new StudentGroup("Group A", new List<string> { "Alice", "Bob" });
            manager.AddGroup(group);

            // Act
            manager.AddGroup(group);

            // Assert (handled by ExpectedException)
        }

        [TestMethod]
        public void RemoveGroup_ShouldRemoveGroup_WhenGroupExists()
        {
            // Arrange
            var manager = new ScheduleManager();
            var group = new StudentGroup("Group A", new List<string> { "Alice", "Bob" });
            manager.AddGroup(group);

            // Act
            manager.RemoveGroup("Group A");

            // Assert
            var groups = manager.GetAllGroups();
            Assert.AreEqual(0, groups.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveGroup_ShouldThrowException_WhenGroupDoesNotExist()
        {
            // Arrange
            var manager = new ScheduleManager();

            // Act
            manager.RemoveGroup("Group B");

            // Assert (handled by ExpectedException)
        }

        [TestMethod]
        public void GetAllGroups_ShouldReturnAllGroups()
        {
            // Arrange
            var manager = new ScheduleManager();
            var group1 = new StudentGroup("Group A", new List<string> { "Alice", "Bob" });
            var group2 = new StudentGroup("Group B", new List<string> { "Charlie", "David" });
            manager.AddGroup(group1);
            manager.AddGroup(group2);

            // Act
            var groups = manager.GetAllGroups();

            // Assert
            Assert.AreEqual(2, groups.Count);
            CollectionAssert.Contains(groups, group1);
            CollectionAssert.Contains(groups, group2);
        }
    }
}


