using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace dotnetside_test.Model
{
    public class EventService
    {
        private List<Attendee> attendees = new List<Attendee>();
        private Event[] eventi;
        private HttpClient http;

        public EventService(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task<Event[]> GetEvents()
        {
            var url = "https://graph.facebook.com/dotnetside/events?access_token=EAAEfhuVqZCDUBABiYQHwk0Qwz9j7C8ljDWfkPewT2z4ZCRtjYBr5FqRqr0svQZB4czgE7snVQCZAe1Lj8ZAP5dxVdWnFHt1pwnqIZAatFG1IWwOeZAOnn92E9B3XLjS9DZA6Ory7UdkzvbZCHUUwCwmMRqgnaacZB3WKRa1ZCUXmnp3NwZDZD";
            var eventResponse = await http.GetJsonAsync<EventResponse>(url);
            eventi = eventResponse.data;
            return eventi;
        }

        public async Task<Event> GetEvent(string eventId)
        {
            return await Task.Run(() => eventi.FirstOrDefault(e => e.id == eventId));
        }

        public async Task<Event> GetNextEvent()
        {
            if (!(eventi?.Any() ?? false))
            {
                await GetEvents();
            }
            return await Task.Run(() => eventi.FirstOrDefault(e => DateTime.Now <= e.start_time));
        }

        public async Task AddAttendee(string eventId, string nome, string cognome)
        {
            await Task.Run(() => attendees.Add(new Attendee { EventId = eventId, Nome = nome, Cognome = cognome}));
        }

        public async Task<Attendee[]> GetEventAttendees(string eventId)
        {
            return await Task.Run(() => attendees.Where(a => a.EventId == eventId).ToArray());
        }
    }
}