function launch() {
  const rocket = document.getElementById("rocket");
  rocket.classList.remove("fly");
  void rocket.offsetWidth; // force reflow
  rocket.classList.add("fly");
}
