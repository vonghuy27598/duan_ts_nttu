//DOM elements
const DOMstrings = {
  stepsBtnClass: 'multisteps-form__progress-btn',
  stepsBtns: document.querySelectorAll('.multisteps-form__progress-btn'),
  stepsBar: document.querySelector('.multisteps-form__progress'),
  stepsForm: document.querySelector('.multisteps-form__form'),
  stepsFormTextareas: document.querySelectorAll('.multisteps-form__textarea'),
  stepFormPanelClass: 'multisteps-form__panel',
  stepFormPanels: document.querySelectorAll('.multisteps-form__panel'),
  stepPrevBtnClass: 'js-btn-prev',
  stepNextBtnClass: 'js-btn-next' };


//remove class from a set of items
const removeClasses = (elemSet, className) => {

  elemSet.forEach(elem => {

    elem.classList.remove(className);

  });

};

//return exect parent node of the element
const findParent = (elem, parentClass) => {

  let currentNode = elem;

  while (!currentNode.classList.contains(parentClass)) {
    currentNode = currentNode.parentNode;
  }

  return currentNode;

};

//get active button step number
const getActiveStep = elem => {
  return Array.from(DOMstrings.stepsBtns).indexOf(elem);
};

//set all steps before clicked (and clicked too) to active
const setActiveStep = activeStepNum => {

  //remove active state from all the state
  removeClasses(DOMstrings.stepsBtns, 'js-active');

  //set picked items to active
  DOMstrings.stepsBtns.forEach((elem, index) => {

    if (index <= activeStepNum) {
      elem.classList.add('js-active');
    }

  });
};

//get active panel
const getActivePanel = () => {

  let activePanel;

  DOMstrings.stepFormPanels.forEach(elem => {

    if (elem.classList.contains('js-active')) {

      activePanel = elem;

    }

  });

  return activePanel;

};

//open active panel (and close unactive panels)
const setActivePanel = activePanelNum => {

  //remove active class from all the panels
  removeClasses(DOMstrings.stepFormPanels, 'js-active');

  //show active panel
  DOMstrings.stepFormPanels.forEach((elem, index) => {
    if (index === activePanelNum) {

      elem.classList.add('js-active');

      setFormHeight(elem);

    }
  });

};

//set form height equal to current panel height
const formHeight = activePanel => {

  const activePanelHeight = activePanel.offsetHeight;

  DOMstrings.stepsForm.style.height = `${activePanelHeight}px`;

};

const setFormHeight = () => {
  const activePanel = getActivePanel();

  formHeight(activePanel);
};
  var jump_step;
//STEPS BAR CLICK FUNCTION

  $('.multisteps-form__progress-btn').click(function (e) {
      const eventTarget = e.target;
      var button = document.querySelectorAll('.multisteps-form__progress-btn');
      const activeStep = Array.from(button).indexOf(eventTarget);
        
      //var i;
      $.each($(".multisteps-form__panel"), function (index)
      {
          if(activeStep>0)
          {
              if (index == activeStep-1)
              {
                  jump_step = true;
                  var getTable = $(this).find("tr").find(".question");
                  $.each(getTable, function () {
                      var point = parseInt($(this).find("input[type='radio']:checked").val()) + 1;
                      if(isNaN(point))
                      {
                          jump_step = false;
                      }
                  
                  })
              }
          }else
          {
              jump_step = true;
          }
                           
      })       
  });


DOMstrings.stepsBar.addEventListener('click', e => {

  //check if click target is a step button
  const eventTarget = e.target;

if (!eventTarget.classList.contains(`${DOMstrings.stepsBtnClass}`)) {
  return;
}

    
      //jump step
      //get active button step number
      const activeStep = getActiveStep(eventTarget);
      if(jump_step){
          //set all steps before clicked (and clicked too) to active
          setActiveStep(activeStep);

          //open active panel
          setActivePanel(activeStep);
          $("html, body").scrollTop(0);
      }else if(!jump_step || isNaN(jump_step))
          alert("Vui lòng trả lời đầy đủ các câu hỏi phía trước");
   
        
  
});
  var next = true;
$(".js-btn-next").click(function(){
    var getTable = $(this).parent().parent().children("table").find("tr").find(".question");
    
    next = true;
    $.each(getTable,function()
    {
        var point = parseInt($(this).find("input[type='radio']:checked").val()) +1;
            
        if (isNaN(point)) {
            next = false;
        }
                
    })
   
    //if(sum == 0)
    //{
    //    alert("Vui lòng trả lời đầy đủ các câu hỏi");
    //}
})
//PREV/NEXT BTNS CLICK
DOMstrings.stepsForm.addEventListener('click', e => {

  const eventTarget = e.target;

  //check if we clicked on `PREV` or NEXT` buttons
  if (!(eventTarget.classList.contains(`${DOMstrings.stepPrevBtnClass}`) || eventTarget.classList.contains(`${DOMstrings.stepNextBtnClass}`)))
  {
    return;
  }

  //find active panel
  const activePanel = findParent(eventTarget, `${DOMstrings.stepFormPanelClass}`);

  let activePanelNum = Array.from(DOMstrings.stepFormPanels).indexOf(activePanel);

  //set active step and active panel onclick
  if (eventTarget.classList.contains(`${DOMstrings.stepPrevBtnClass}`)) {
    activePanelNum--;

  } else {
      //check trả lời đủ câu hỏi
    
     
        if(!next)
        {
            alert("Vui lòng trả lời đầy đủ các câu hỏi");
        }else{

            activePanelNum++;
            $("html, body").scrollTop(0);
        }
    

  }

  setActiveStep(activePanelNum);
  setActivePanel(activePanelNum);

});

//SETTING PROPER FORM HEIGHT ONLOAD
window.addEventListener('load', setFormHeight, false);

//SETTING PROPER FORM HEIGHT ONRESIZE
window.addEventListener('resize', setFormHeight, false);

//changing animation via animation select !!!YOU DON'T NEED THIS CODE (if you want to change animation type, just change form panels data-attr)

const setAnimationType = newType => {
  DOMstrings.stepFormPanels.forEach(elem => {
    elem.dataset.animation = newType;
  });
};

//selector onchange - changing animation
const animationSelect = document.querySelector('.pick-animation__select');

animationSelect.addEventListener('change', () => {
  const newAnimationType = animationSelect.value;

  setAnimationType(newAnimationType);
});