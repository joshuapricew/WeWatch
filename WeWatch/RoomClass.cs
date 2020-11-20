using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WeWatch
{
    public class Room
    {
        public readonly string RoomId = GenerateRoomID();

        private List<Client> Clients = new List<Client>();

        public Room(Client hostClient)
        {
            Clients.Add(hostClient);
        }
        
        /// <summary>
        /// Generates and returns a unique 4 character base64 string.
        /// </summary>
        /// <returns>A 4 character base64 string</returns>
        // TODO: Add parameter which takes list of all RoomIds currently
        // being tracked by the program so that this class can check that 
        // it is generating a fully unique Id for this server.
        static private string GenerateRoomID()
        {
            string RoomId;
            do {

                byte[] RoomGuidBytes = Guid.NewGuid().ToByteArray();
                // Only get a number of bits that is a common multiple of both 6 and 8.
                byte[] RoomIdBytes = new byte[]
                {
                    RoomGuidBytes[0],
                    RoomGuidBytes[1],
                    RoomGuidBytes[2]
                };
                RoomId = Convert.ToBase64String(RoomIdBytes);
                /* If the base64 contains either a + or a /, try again. */
            } while (Regex.IsMatch(RoomId, "[+/]"));
            return RoomId;
        }
    }
}