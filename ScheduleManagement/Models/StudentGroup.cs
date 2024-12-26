using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Models;

public class StudentGroup
{
    public string GroupName { get; }
    public List<string> Students { get; }

    public StudentGroup(string groupName, List<string> students)
    {
        if (string.IsNullOrWhiteSpace(groupName))
            throw new ArgumentException("Group name cannot be empty.", nameof(groupName));

        GroupName = groupName;
        Students = students ?? new List<string>();
    }
}

