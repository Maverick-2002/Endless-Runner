mergeInto(LibraryManager.library, {
  
  AskQuestion_React: function () {
    try {
      window.dispatchReactUnityEvent("AskQuestion_React");
    } catch (e) {
      console.warn("Failed to dispatch event : AskQuestion_React");
    }
  },
  StartGame_React: function () {
    try {
      window.dispatchReactUnityEvent("StartGame_React");
    } catch (e) {
      console.warn("Failed to dispatch event : StartGame_React");
    }
  },
  GameOver_React: function (gameScore) {
    try {
      window.dispatchReactUnityEvent("GameOver_React", gameScore);
    } catch (e) {
      console.warn("Failed to dispatch event : GameOver_React");
    }
  },
});