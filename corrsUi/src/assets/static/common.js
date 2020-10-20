Date.prototype.getWeek = function() {
    var date = new Date(this.getTime())
    date.setHours(0, 0, 0, 0)
    date.setDate(date.getDate() + 3 - (date.getDay() + 6) % 7)
    var week1 = new Date(date.getFullYear(), 0, 4)
    return 1 + Math.round(((date.getTime() - week1.getTime()) / 86400000 - 3 + (week1.getDay() + 6) % 7) / 7)
}
  
function DateRangeOfWeek(weekNo, y){
    var d1, numOfdaysPastSinceLastMonday, rangeIsFrom, rangeIsT
    d1 = new Date(''+y+'');
    numOfdaysPastSinceLastMonday = d1.getDay() - 1
    d1.setDate(d1.getDate() - numOfdaysPastSinceLastMonday)
    d1.setDate(d1.getDate() + (7 * (weekNo - d1.getWeek())))
    rangeIsFrom = (d1.getMonth() + 1) + "/" + d1.getDate() + "/" + d1.getFullYear()
    d1.setDate(d1.getDate() + 6)
    rangeIsTo = (d1.getMonth() + 1) + "/" + d1.getDate() + "/" + d1.getFullYear()
    return rangeIsFrom + " to " + rangeIsTo
}

function GetWeekArr(result){
    var currentYearWeekNoArr = result[1]
    var lastYearWeekNoArr = 52 - result[1]
    var weekNo = []
    for (let i = 0; i < currentYearWeekNoArr; i++) {
      weekNo.push(
        {
          "value":i+1,
          "week": i+1,
          "year":result[0]
        }
      )
    }
    for (let e = 0; e < lastYearWeekNoArr; e++) {
      let cnt = e+1
      weekNo.push(
        {
          "value":cnt+currentYearWeekNoArr,
          "week": cnt+currentYearWeekNoArr,
          "year": result[0]-1
        }
      )
    }
    var range = []
    for (let j = 0; j < weekNo.length; j++) {
      range.push({
        "value": weekNo[j].week,
        "label": "W " + weekNo[j].week + ' - ' +DateRangeOfWeek(weekNo[j].week, weekNo[j].year)
      })
    }
    return range
}

function validateRowReasonSelect(e, i, d, m){
  var checkVal = document.getElementById('check'+i).checked
  // var name = e.target.value
  return checkVal ? "Hit" : "Miss"
  // var saveData = {
  //   "resource": d.resource,
  //   "flag": checkVal,
  //   "processOrder":d.processOrder,
  //   "ReasonCodeId":name,
  //   "MetricId":m,
  //   "IDCheck": 'check'+i,
  //   "IdSel": 'select'+i
  // }
  // if((!saveData.flag && saveData.ReasonCodeId == '') || (saveData.flag && saveData.ReasonCodeId != '')){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.remove("error")
  //   check.nextSibling.classList.remove("err-border")
  // }else if(saveData.flag && saveData.ReasonCodeId == ''){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.add("error")
  //   check.nextSibling.classList.remove("err-border")
  // }else if(!saveData.flag && saveData.ReasonCodeId != ''){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.remove("error")
  //   check.nextSibling.classList.add("err-border")
  // }
  // if(saveData.flag && saveData.ReasonCodeId != ''){
  //   saveData.flag = saveData.flag ? 'Hit' : false
  //   saveData.ReasonCodeId  = saveData.ReasonCodeId != '' ? parseInt(saveData.ReasonCodeId) : ''
  //   return saveData
  // }
}
function validateRowCheck(e, i, d, m){
  return checkVal = document.getElementById('select'+i).value
  // var name = e.target.checked
  // var saveData = {
  //   "resource": d.resource,
  //   "flag": name,
  //   "processOrder":d.processOrder,
  //   "ReasonCodeId":checkVal,
  //   "MetricId":m,
  //   "IDCheck": 'check'+i,
  //   "IdSel": 'select'+i
  // }
  // if((!saveData.flag && saveData.ReasonCodeId == '') || (saveData.flag && saveData.ReasonCodeId != '')){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.remove("error")
  //   check.nextSibling.classList.remove("err-border")
  // }else if(saveData.flag && saveData.ReasonCodeId == ''){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.add("error")
  //   check.nextSibling.classList.remove("err-border")
  // }else if(!saveData.flag && saveData.ReasonCodeId != ''){
  //   var checkSel = document.getElementById('select'+i)
  //   var check = document.getElementById('check'+i)
  //   checkSel.classList.remove("error")
  //   check.nextSibling.classList.remove("err-border")
  // }
  // if(saveData.flag && saveData.ReasonCodeId != ''){
  //   saveData.flag = saveData.flag ? 'Hit' : false
  //   saveData.ReasonCodeId  = saveData.ReasonCodeId != '' ? parseInt(saveData.ReasonCodeId) : ''
  //   return saveData
  // }
}
function FilterData(data){
  var e = []
  for (let i = 0; i < data.length; i++) {
    var c = data[i].plantId
    e.push(c)
  }
  return e
}

function FilterPlantData(data){
  var e = []
  for (let i = 0; i < data.length; i++) {
    var c = data[i].plantDomain
    e.push(c)
  }
  return e
}