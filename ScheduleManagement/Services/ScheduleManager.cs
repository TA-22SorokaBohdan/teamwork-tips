using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScheduleManagement.Models;

namespace ScheduleManagement.Services;

public class ScheduleManager
{
    private readonly List<StudentGroup> _groups = new();

    public void AddGroup(StudentGroup group)
    {
        if (_groups.Any(g => g.GroupName == group.GroupName))
            throw new InvalidOperationException($"Group '{group.GroupName}' already exists.");

        _groups.Add(group);
    }

    public void RemoveGroup(string groupName)
    {
        var group = _groups.FirstOrDefault(g => g.GroupName == groupName);
        if (group == null)
            throw new KeyNotFoundException($"Group '{groupName}' not found.");

        _groups.Remove(group);
    }

    public List<StudentGroup> GetAllGroups()
    {
        return new List<StudentGroup>(_groups);
    }
}

