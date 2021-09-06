using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Airteliq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Airteliq.Controllers
{
    /// <summary>
    /// The main Airteliq api controller class
    /// Contains methods for api endpoints
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AirteliqController : ControllerBase
    {
        private readonly ILogger<AirteliqController> _logger;
        private AirteliqConfig AirteliqConfig;

        public AirteliqController(ILogger<AirteliqController> logger, AirteliqConfig iConfig)
        {
            _logger = logger;
            AirteliqConfig = iConfig;
        }

        /// <summary>
        /// Method to get info about Airteliq room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Result of the room</returns>
        [HttpGet("/api/get-room/{roomId}")]
        public async Task<string> GetRoom(string roomId)
        {
            // build auth token for using Airteliq video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AirteliqConfig.AIRTELIQ_APP_ID}:{AirteliqConfig.AIRTELIQ_APP_KEY}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // Airteliq get room details api - /api/rooms/{roomId}
            string apiEndpoint = $"{AirteliqConfig.AIRTELIQ_API_URL}rooms/{roomId}";

            var result = await client.GetAsync(apiEndpoint);
            return await result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Method to create Airteliq room
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/create-room")]
        public async Task<string> CreateRoom()
        {
            #region
            // Build JSON Raw Body Payload for creating Airteliq room
            RoomBodySip roomBodySip = new RoomBodySip();
            roomBodySip.enabled = false;

            RoomBodySettings roomBodySettings = new RoomBodySettings();
            roomBodySettings.scheduled = false;
            roomBodySettings.adhoc = true;
            roomBodySettings.moderators = "1";
            roomBodySettings.participants = "1";
            roomBodySettings.duration = "30";
            roomBodySettings.quality = "SD";
            roomBodySettings.auto_recording = false;

            var rand = new Random();
            int randNum = rand.Next();

            RoomBody roomBody = new RoomBody();
            roomBody.name = $"Sample Room {randNum}";
            roomBody.owner_ref = $"{randNum}";
            roomBody.settings = roomBodySettings;
            roomBody.sip = roomBodySip;
            #endregion

            // build auth token for using Airteliq video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AirteliqConfig.AIRTELIQ_APP_ID}:{AirteliqConfig.AIRTELIQ_APP_KEY}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            
            // Airteliq create room api - /api/rooms/
            string apiEndpoint = $"{AirteliqConfig.AIRTELIQ_API_URL}rooms/";

            var json = JsonConvert.SerializeObject(roomBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiEndpoint, data);

            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Method to create Airteliq room
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/room/multi")]
        public async Task<string> CreateRoomMulti()
        {
            #region
            // Build JSON Raw Body Payload for creating Airteliq room
            RoomBodySip roomBodySip = new RoomBodySip();
            roomBodySip.enabled = false;

            RoomBodySettings roomBodySettings = new RoomBodySettings();
            roomBodySettings.scheduled = false;
            roomBodySettings.adhoc = true;
            roomBodySettings.moderators = "1";
            roomBodySettings.participants = "5";
            roomBodySettings.duration = "30";
            roomBodySettings.quality = "SD";
            roomBodySettings.auto_recording = false;

            var rand = new Random();
            int randNum = rand.Next();

            RoomBody roomBody = new RoomBody();
            roomBody.name = $"Sample Room {randNum}";
            roomBody.owner_ref = $"{randNum}";
            roomBody.settings = roomBodySettings;
            roomBody.sip = roomBodySip;
            #endregion

            // build auth token for using Airteliq video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AirteliqConfig.AIRTELIQ_APP_ID}:{AirteliqConfig.AIRTELIQ_APP_KEY}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // Airteliq create room api - /api/rooms/
            string apiEndpoint = $"{AirteliqConfig.AIRTELIQ_API_URL}rooms/";

            var json = JsonConvert.SerializeObject(roomBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiEndpoint, data);

            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Method to create Airteliq token
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/create-token")]
        public async Task<string> CreateToken()
        {
            string requestJSON = await new StreamReader(Request.Body).ReadToEndAsync();
            if (!String.IsNullOrEmpty(requestJSON)) {
                CreateTokenBody createTokenBody = JsonConvert.DeserializeObject<CreateTokenBody>(requestJSON);

                // build auth token for using Airteliq video API
                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AirteliqConfig.AIRTELIQ_APP_ID}:{AirteliqConfig.AIRTELIQ_APP_KEY}"));

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                // Airteliq create token api - /api/rooms/{roomId}/tokens
                string apiEndpoint = $"{AirteliqConfig.AIRTELIQ_API_URL}rooms/{createTokenBody.roomId}/tokens";

                var data = new StringContent(requestJSON, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiEndpoint, data);

                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }
        }
    }
}
