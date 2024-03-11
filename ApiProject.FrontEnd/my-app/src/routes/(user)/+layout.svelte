<script>
    import { setContext, getContext } from 'svelte'
    
</script>

<div>
<a style="border-radius: 20px; width:30px;" href="/">&lt Връщане</a>
</div>
 
<slot/>

<style>
    div{
       margin-top: 30px;
    }
    a{
        font-family: Arial, sans-serif;
        border-style: dashed;
        padding: 10px;
        border-style:none;
        border-width: 4px;
        border-radius: 20px;
        width: 150px;
        height: auto;
        margin-top: 150px;
        margin-left: 40px;
        border-color: black;
        background-color: #004080;
        text-decoration: none;
        color: white;
        
        border-radius: 20px; 
        box-shadow: 0px 0px 10px rgba(0,0,0,0.15); 
    }
</style>
