const fortunes = [
  "You will have a great day!",
  "Success is coming your way.",
  "An old friend will contact you.",
  "You will discover something new.",
  "Today is your lucky day!",
  "Expect good news soon.",
  "A surprise awaits you.",
  "You will achieve your goal.",
  "Stay positive and strong.",
  "Something wonderful is about to happen.",
  "Your hard work will pay off.",
  "A new opportunity is on the horizon.",
  "You will find joy in the little things.",
  "A journey will bring you happiness.",
  "Your kindness will be rewarded.",    
];

function getFortune() {
  const index = Math.floor(Math.random() * fortunes.length);
  const message = fortunes[index];
  document.getElementById("fortune").textContent = message;
}