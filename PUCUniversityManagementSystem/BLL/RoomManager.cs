using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class RoomManager
    {
        RoomGateway roomGateway=new RoomGateway();
        public IEnumerable<Room> GetAllRooms
        {
            get { return roomGateway.GetAllRooms; }
        }
    }
}