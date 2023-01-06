

fetch('../unity/src/PlayerController.cs')
  .then(response => response.text())
  .then(data => {
    // Store the C# code in a variable
    const code = data;
    document.getElementById('code-view').innerHTML = code;
  });