var possibleInput = ["Type", "Ipok", "Ipokf","Infer","If","Else","Sipok","Craf","Sequance","Sipokf","Valueless","Rational","Endthis","However","When","Respondwith","Srap","Scan","Conditionof","Require"]
var splitedInput, lastWord, lines, lastLine, suggestedWords, myReg;

function textSuggest(textField) {
    var showSuggest = document.getElementById("suggestField");
    $("#suggestField").empty();
    //add first default option
    var opt = document.createElement('option');
    opt.disabled = true;
    opt.selected = true;
    opt.innerHTML = "Show Suggestions";
    showSuggest.appendChild(opt);
    //--------
    lines = textField.value.split("\n");
    lastLine = lines[lines.length - 1]
    splitedInput = lastLine.split(" ");
    lastWord = splitedInput[splitedInput.length - 1];

    for (var index in possibleInput) {
        lastWord = lastWord.toLowerCase();
        myReg = new RegExp(lastWord + ".*")
        suggestedWords = possibleInput[index].toLowerCase().match(myReg);
        for (var suggestIndex in suggestedWords) {
            if (suggestedWords[suggestIndex] != null) {
                var opt = document.createElement('option');
                opt.value = possibleInput[index];
                opt.innerHTML = possibleInput[index];
                showSuggest.appendChild(opt);
                break;
            }
        }
    }
}

var codeEditor = document.getElementById('codeEditor');
var lineCounter = document.getElementById('lineCounter');
var lineCountCache = 0;

function line_counter() {
    var lineCount = codeEditor.value.split('\n').length;
    var outarr = new Array();
    if (lineCountCache != lineCount) {
        for (var x = 0; x < lineCount; x++) {
            outarr[x] = (x + 1);
        }
        lineCounter.value = outarr.join('\n');

    }
    lineCountCache = lineCount;
}



function SelectedValue(suggestedValue) {
    var value = suggestedValue.options[suggestedValue.selectedIndex].value;
    var lastIndex = codeEditor.value.lastIndexOf(" ");
    codeEditor.value = codeEditor.value.substring(0, lastIndex) + " " + value;

}


codeEditor.addEventListener('scroll', () => {
    lineCounter.scrollTop = codeEditor.scrollTop;
    lineCounter.scrollLeft = codeEditor.scrollLeft;
});

codeEditor.addEventListener('input', () => {
    line_counter();
});