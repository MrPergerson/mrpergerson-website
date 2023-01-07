
function getCode(link)
{
  fetch(link)
  .then(response => response.text())
  .then(data => {
    // Store the C# code in a variable
    let code = data;
    code = cleanUpCode(code);
    document.getElementById('code-view').innerHTML = code;

    hljs.highlightAll();
  });

}


function cleanUpCode(code)
{

  code = code.replaceAll("<","&lt;");
  code = code.replaceAll(">","&gt;");
  code = code.replaceAll("\"","&quot;");

  return code;
}