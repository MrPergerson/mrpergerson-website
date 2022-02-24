const url = '../files/webdev_resume.pdf';

// Loaded via <script> tag, create shortcut to access PDF.js exports.
var pdfjsLib = window['pdfjs-dist/build/pdf'];

// The workerSrc property shall be specified.
pdfjsLib.GlobalWorkerOptions.workerSrc = '//mozilla.github.io/pdf.js/build/pdf.worker.js';

let pdfDoc = null,
pageNum = 1,
pageIsRendering = false;
pageNumIsPending = null;

const scale = 1.5,
canvas = document.querySelector('#pdf-render'),
ctx = canvas.getContext('2d');


//console.log(pdfjsLib);
// Render the page
const renderPage = num => {
   pageIsRendering = true;

    // Get the page
    pdfDoc.getPage(num).then(page => {
        console.log(page);
        // Set scale
        const viewport = page.getViewport({scale});
        canvas.height = viewport.height;
        canvas.width = viewport.width;

        const renderContext = {
            canvasContext: ctx, viewport
        }

        page.render(renderContext).promise.then(() => {
            pageIsRendering = false;

            if(pageNumIsPending !== null)
            {
                renderPage(pageNumIsPending);
                pageNumIsPending = null;
            }
        });
    });

    // Output current page
    //document.querySelector('#page-num').textContent = num;
    
}

// Get Docucement
pdfjsLib.getDocument(url).promise.then(function(pdfDoc_) {
    console.log('PDF loaded');
    pdfDoc = pdfDoc_;
    console.log(pdfDoc);
    
    //document.querySelector('#page-count').textContent = pdfDoc.numPages;
    renderPage(pageNum);
    
});