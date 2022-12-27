using CerealGame.Bff;
using CerealGame.ClockService;
using CerealGame.GameOrchestrator;
using CerealGame.UI;
using UiService = CerealGame.Bff.UserInterfaceService;
using EventService = CerealGame.EventService.TimeEventService;

var ui = new UserInterface();
var bff = new UiService(ui);
var orch = new GameOrchestrator();
var eventService = new EventService(orch, bff);
var clockService = new ClockService(eventService);

Console.WriteLine("Starting game");

clockService.Start();