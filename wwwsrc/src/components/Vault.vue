<template>
  <div class="col-6 col-md-4">
    <div class="card">
      <router-link
        :to="{name: 'VaultDetails', params: {id: this.vaultData.id, name: this.vaultData.name}}"
      >
        <img
          class="card-img-top"
          src="https://www.gleason-group.net/wp-content/uploads/2018/03/vault-1.jpg"
          alt
        />
        <div class="card-body">
          <h4 class="card-title text-center">{{vaultData.name}}</h4>
          <p class="card-text text-center">{{vaultData.description}}</p>
          <!-- <p class="text-center">Keeps: {{}}</p> -->
          <button @click="deleteVault" title="Delete this Vault" class="btn btn-danger">X</button>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"],
  computed: {},
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  }
};
</script>

<style scoped>
</style>