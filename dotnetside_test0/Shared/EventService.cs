using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace dotnetside.Shared
{
    public class EventService
    {
        private Event[] events;
        private HttpClient http;

        public EventService(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task<Event[]> GetEvents()
        {
            var url = "https://graph.facebook.com/dotnetside/events?access_token=EAAEfhuVqZCDUBABiYQHwk0Qwz9j7C8ljDWfkPewT2z4ZCRtjYBr5FqRqr0svQZB4czgE7snVQCZAe1Lj8ZAP5dxVdWnFHt1pwnqIZAatFG1IWwOeZAOnn92E9B3XLjS9DZA6Ory7UdkzvbZCHUUwCwmMRqgnaacZB3WKRa1ZCUXmnp3NwZDZD";
            var eventResponse = await http.GetJsonAsync<EventResponse>(url);
            events = eventResponse.data;
            return events;
        }

        public async Task<Event> GetEvent(string eventId)
        {
            return await Task.Run(() => events.FirstOrDefault(e => e.id == eventId));
        }
    }
}