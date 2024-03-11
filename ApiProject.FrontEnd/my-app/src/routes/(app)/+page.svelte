<script lang="ts">
    
    import { enhance } from '$app/forms';
    import { goto } from '$app/navigation';
    import type { PageData } from './$types';
    export let data:PageData
    import { fade, fly } from 'svelte/transition';
    import Layout from './+layout.svelte';
   
    import { get } from 'svelte/store';
    import { onMount } from 'svelte';
    import { browser } from '$app/environment';
   
    
    let y = 0
    let temp_y = y 
    let chosenPayment = ""
    let chosenType = ""
    console.log(chosenType)
    const majorType = [
        "Редовно","Задочно"
    ]
    const majorPayment = [
        "Държавна","Платено"
    ]
    
    $:choicePageSelected = "block"
    $:chosenMajor = {
        name:"",
        payment:"",
        type:""
    }
    $:majorId = ""
    const majors = data.major
    let confirmMajorPageVisibility = "none"
    let searchTerm = ''
    $:searchedMajors = majorsFilteredByType.filter((major) => {return major.name.toLowerCase().includes(searchTerm.toLowerCase())})
    $:majorsFilteredByType = majorsFilteredByPayment.filter((major) => {return major.type.includes(chosenType)})
    $:majorsFilteredByPayment = majors.filter((major) => {return major.paymentType.includes(chosenPayment)})
    
    function changePageToSelectedMajor(major_name,major_payment,major_type,major_id)
    {
        choicePageSelected = "none"
        temp_y = y
        if(data.user == undefined){
           goto("/login")
           return
        }
        chosenMajor.name = major_name,
        chosenMajor.payment = major_payment,
        chosenMajor.type =major_type
        majorId = major_id
        confirmMajorPageVisibility = "block"

       
    }
    function goBackToMajorsPage(){
        choicePageSelected = "block"
        chosenMajor.name = ""
        confirmMajorPageVisibility = "none"
        
        
        setTimeout(function () {
            window.scrollTo(0, temp_y);
        },2);
    }
    function confirmMajor(){
        
    }
    
   
</script>

<svelte:window bind:scrollY={y}/>



<div class="text-container">
    <h1>
        Акция Рано рани
    </h1>
<p class="intro">
        Великотърновският университет „Св. св. Кирил и Методий“ предлага на 
    своите кандидат-студенти възможност за запазване на място в една 
    предпочитана специалност с гаранции от Университета за по-късно записване. От запазването на място могат да се възползват всички кандидати, които са завършили средно образование или на които им предстои завършване на средно образование. Запазването на място в една предпочитана специалност става само ЕЛЕКТРОННО чрез подаване на заявление в тази платформа и внасяне на такса за обработка на документите. 
</p>
<p class="intro">За да запазите място е необходимо е да: </p>
<p class="intro">1. Направите в тази платформа регистрация чрез валидни лични данни и валиден адрес на електронната Ви поща. </p>
<p class="intro">2. Потвърдите регистрацията с получения код за достъп в електронната Ви поща (ако не сте получили такъв, моля, проверете и в СПАМ). При възникнали проблеми се обадете на тел. 062/618 206 или 0879392839.</p>
<p class = "intro">3. Изберете желаната от Вас специалност в съответната форма на обучение (редовна или задочна) и вида на таксата (държавна поръчка или платено обучение) от списъка. Имате възможност само на ЕДНО ЖЕЛАНИЕ. </p>
<p class="info">4. Направите плащане на таксата по банков път и прикачете копие на платежното нареждане във формат PNG или JPG в рамките на един работен ден. </p>
<p class="info">Ако сте преминали успешно четирите стъпки ще получите потвърждение за запазеното място по акция „Рано рани“ в тази електронна система. </p>
<p class="info">Запазването на място ще продължи до попълването на обявените места. Информацията за оставащите свободни места се обновява в реално време. </p>
<p class="info">Обявените бройки за запазване на място или ранно записване са само част от капацитета на Университета за прием на студенти.</p>
<p class="info">За повече информация можете да се обадите и на телефон 062/618 206 или 0879392839.</p>
</div>


<div  class = "choicePage" style="display: {choicePageSelected};">
<div class="search-param">
    <input style="height:30px;width:300px" name = "search" type = "text" placeholder="Специалост" bind:value={searchTerm}>
    <select bind:value={chosenType}>
    <option value=""  selected>Избрете форма на обучение</option>
		{#each majorType as type}
			<option value={type}>
				{type}
			</option>
		{/each}
	</select>
    <select bind:value={chosenPayment}>
        <option value=""  selected>Избрете вид такса</option>
            {#each majorPayment as payment}
                <option value={payment}>
                    {payment}
                </option>
            {/each}
        </select>
</div>
{#key choicePageSelected}
<div class="major-box">

{#if searchedMajors.length > 0}
    {#each searchedMajors as major}
    
    <div class="major-style" in:fly={{ x:-200,duration:200,delay:300}} out:fly={{x: 200,duration:200}}>
        <p><span class = "info">Код:</span>{major.id}</p>
        <p style="height: 50px;"><span class = "info">Специалност:</span>{major.name}</p>
        <p ><span class = "info">Форма:</span>{major.type}</p>
        <p><span class = "info">Вид такса:</span>{major.paymentType}</p>
        <p><span class = "info">Свободни места:</span>Останали места:{major.placesLeft}</p>
        {#if data.user?.request_status != "Платена"}
            <button class = "style-button"  on:click={() => changePageToSelectedMajor(major.name,major.paymentType,major.type,major.id)}>Запази място</button>   
        {:else}
            <p style="display: none;">Вие вече сте запазили място!</p>  
        {/if}
    </div>
    

{/each}
{:else}
    <h2>Няма резултати</h2>
{/if}

</div>
{/key}
</div>


{#key confirmMajorPageVisibility}

<div class ="confirm-major" style="display: {confirmMajorPageVisibility};" in:fly={{ x:-200,duration:200}} out:fly={{x: 200,duration:200}}>
    <button on:click={goBackToMajorsPage}>Назад</button>
    <form method="POST" action="/set_major" use:enhance in:fly={{ x:-200,duration:200}} out:fly={{x: 200,duration:200}}>
        <input type= "hidden" name = "major"  value="{chosenMajor.name}" />
        <input type= "hidden" name ="majorid" value="{majorId}" />
        <p class = "selected">{chosenMajor.name}</p>
        <p class = "selected">{chosenMajor.payment}</p>
        <p class = "selected">{chosenMajor.type}</p>
        <p>Сигурни ли сте?</p>
        <button on:click={confirmMajor}>Запази място</button>
    </form>
</div>
{/key}


<style>
    .confirm-major{
        margin-left: 10px;
        margin-bottom: 80px;
        padding:20px;
        border-style:solid ;
        border-radius: 5px;
        border-width: 1px;
        width:30%;
    }
    .info{
        font-family: Arial, sans-serif;
        font-size: 16px;
        color: #666; 
    }
    .selected{
        font-size: 32px;
    }
    select{
        width: 300px;
        background-color: white;
        
        padding: 10px;
        font-size: 16px;
        border-radius: 5px;
    }
    .choicePage{
        min-height: 300px;
        background-color: white;
        margin-bottom: 30px;
    }
    .search-param{
        gap:30px;
        display: flex;
        height: 10%;
        align-items: center;
        justify-content: center;
        margin: 30px;
    }
    .major-style{
        
        border-style: solid;
        border-width: 1px;
        border-color: black;
        flex-wrap: wrap;
        width: 20%;
        padding:20px;
        background-color: white;
        border-radius: 5px;
        height: 250px;
    }
    .major-box{
        margin-left: 50px;
        gap:30px;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }
    h1{
        font-family: Arial, sans-serif;
        color: #333;
    }
    .text-container{
       margin: 30px; 
    }
    .intro{
        
        color: #666;
    }
    button{
        background-color: white;
        height: 20px;
        font-family: Arial, sans-serif;
        border-style: solid;
    }
   
    p{
        font-family: Arial, sans-serif;
        font-size: 16px;
    }
</style>


